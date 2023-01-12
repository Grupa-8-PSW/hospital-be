using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Firebase.Auth;
using Firebase.Storage;
using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model.ValueObject;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Core.Service.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using Document = iTextSharp.text.Document;

namespace IntegrationLibrary.Core.Service
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly ITenderOfferRepository _tenderOfferRepository;

        public TenderService(ITenderRepository tenderRepository, ITenderOfferRepository tenderOfferRepository)
        {
            _tenderRepository = tenderRepository;
            _tenderOfferRepository = tenderOfferRepository;
        }

        public IEnumerable<Tender> GetAll()
        {
            return _tenderRepository.GetAll();
        }

        public void Create(Tender tender)
        {
            _tenderRepository.Create(tender);
        }

        public Tender GetById(int id)
        {
            return _tenderRepository.GetById(id);
        }

        public void Delete(Tender tender)
        {
            _tenderRepository.Delete(tender);
        }

        public IEnumerable<Tender> GetActiveTenders()
        {
            return _tenderRepository.GetActiveTenders();
        }

        public Tender UpdateStatus(int tenderID)
        {
            Tender tender = _tenderRepository.GetById(tenderID);
            tender.EndTenderLifeCycle();
            _tenderRepository.Update(tender);
            return tender;
        }

        public void Update(Tender tender)
        {
            _tenderRepository.Update(tender);
        }



        private void CreateTable(List<Dictionary<String, int>> amountsForEachBloodBank, DateTime fromDate, DateTime toDate, Document document)
        {
            PdfPTable table = new PdfPTable(9);
            CreateHeaderCell(table, "Blood Bank Name");
            CreateHeaderCell(table, "A+");
            CreateHeaderCell(table, "A-");
            CreateHeaderCell(table, "B+");
            CreateHeaderCell(table, "B-");
            CreateHeaderCell(table, "AB+");
            CreateHeaderCell(table, "AB-");
            CreateHeaderCell(table, "0+");
            CreateHeaderCell(table, "0-");


            Paragraph para1 = new Paragraph("Report from date " + fromDate.Date.ToShortDateString() + " to date " + toDate.Date.ToShortDateString(), new Font(Font.FontFamily.HELVETICA, 20));
            para1.Alignment = Element.ALIGN_CENTER;
            para1.SpacingAfter = 10;
            document.Add(para1);



            foreach (var amountForEachBank in amountsForEachBloodBank)
            {
                PdfPCell cell_1 = new PdfPCell(new Phrase(""));

                cell_1.Phrase.Add(amountForEachBank.Keys.Last());
                cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell_1);

                CreateQuantityCell(table, amountForEachBank, "A+");
                CreateQuantityCell(table, amountForEachBank, "A-");
                CreateQuantityCell(table, amountForEachBank, "B+");
                CreateQuantityCell(table, amountForEachBank, "B-");
                CreateQuantityCell(table, amountForEachBank, "AB+");
                CreateQuantityCell(table, amountForEachBank, "AB-");
                CreateQuantityCell(table, amountForEachBank, "0+");
                CreateQuantityCell(table, amountForEachBank, "0-");

            }

            document.Add(table);
        }


        private static void CreateHeaderCell(PdfPTable table, string headerText)
        {
            PdfPCell cell = new PdfPCell(new Phrase(headerText, new Font(Font.FontFamily.HELVETICA, 10)));
            cell.BackgroundColor = BaseColor.RED;
            cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                           Rectangle.RIGHT_BORDER;
            cell.BorderWidthBottom = 1f;
            cell.BorderWidthTop = 1f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthRight = 1f;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
        }

        private static void CreateQuantityCell(PdfPTable table, Dictionary<String, int> amountForBloodBank, String bloodType)
        {
            PdfPCell qCell = new PdfPCell(new Phrase(""));
            qCell.HorizontalAlignment = Element.ALIGN_CENTER;


            if (amountForBloodBank.ContainsKey(bloodType))
            {
                qCell.Phrase.Add(amountForBloodBank[bloodType].ToString());
                qCell.HorizontalAlignment = Element.ALIGN_CENTER;
               
            }
            else
            {
                qCell.Phrase.Add("");
                qCell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            table.AddCell(qCell);
        }


        private async Task<byte[]> UploadFile(byte[] file)
        {
            var stream = new MemoryStream(file);

            //authentication
            var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAQTVZHRWBwsKNe7VVV7X5uCOqyb33MEUA"));
            var a = await auth.SignInWithEmailAndPasswordAsync("asdf@gmail.com", "asdf123");

            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage(
                "isapsw-6ef61.appspot.com",
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true,
                })
                .Child("urgentRequestStatistics")
                .Child("urgentRequests" + Guid.NewGuid() + ".pdf")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            stream.Close();
            return file;
        }


        public List<Dictionary<string, int>> GetBloodAmountsBetweenDates(DateTime from, DateTime to)
        {
            List<TenderOffer> toRet = new List<TenderOffer>();
            foreach (Tender tender in _tenderRepository.GetTendersBetweenDates(from, to))
            {
                if (tender.GetAcceptedOffer() == null)
                    continue;
                
                toRet.Add(tender.GetAcceptedOffer());
            }

            List<String> bankNames = FindBankNames(toRet);

            List<Dictionary<string, int>> quants = new List<Dictionary<string, int>>();

            foreach (String bankName in bankNames)
            {
                quants.Add(new Dictionary<string, int>(CalculateQuantitiesForBank(bankName, toRet)));
            }

            return quants;
        }

        private List<String> FindBankNames(List<TenderOffer> offers)
        {
            List<String> allNames = new List<string>();
            foreach (TenderOffer tenderOffer in offers)
            {
                allNames.Add(tenderOffer.BloodBankName);
            }

            return allNames.Distinct().ToList();

        }

        private Dictionary<string, int> CalculateQuantitiesForBank(String bankName, List<TenderOffer> allOffers)
        {
            List<String> allTypes = new List<string>();

            foreach (TenderOffer tenderOffer in allOffers)
            {
                if (tenderOffer.BloodBankName.Equals(bankName))
                {
                    allTypes.AddRange(tenderOffer.Offers.Select(tenderOfferOffer => tenderOfferOffer.BloodType));
                }
            }

            return FindQuantitiesForTypes(bankName, allOffers, allTypes.Distinct().ToList());
        }


        private Dictionary<string, int> FindQuantitiesForTypes(String bankName, List<TenderOffer> allOffers, List<String> allTypes)
        {
            Dictionary<string, int> typesAndQuantities = new Dictionary<string, int>();

            foreach (var type in allTypes)
            {
                typesAndQuantities.Add(type, 0);
            }

            foreach (string type in allTypes)
            {
                foreach (TenderOffer tenderOffer in allOffers)
                {
                    if (tenderOffer.BloodBankName.Equals(bankName))
                    {
                        foreach (var offer in tenderOffer.Offers)
                        {
                            if (offer.BloodType.Equals(type))
                            {
                                typesAndQuantities[type] += offer.BloodAmount;
                            }
                        }
                    }
                }
            }

            typesAndQuantities.Add(bankName, GetSumForBank(typesAndQuantities));

            return typesAndQuantities;
        }

        private int GetSumForBank(Dictionary<string, int> typesAndQuantities)
        {
            int sum = 0;
            foreach (var item in typesAndQuantities)
            {
                sum += item.Value;
            }

            return sum;
        }


        public async Task<byte[]> GeneratePdf(List<Dictionary<string, int>> amountsForEachBloodBank, DateTime fromDate, DateTime toDate)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                writer.Open();
                document.Open();

                CreateTable(amountsForEachBloodBank, fromDate, toDate, document);

                document.Close();
                writer.Close();
                var constant = ms.ToArray();
                try
                {
                    await UploadFile(constant);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                
                return constant;
            }
        }
    }
}
