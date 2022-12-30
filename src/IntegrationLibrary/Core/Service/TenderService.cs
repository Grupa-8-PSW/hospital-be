using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
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


        public async Task<byte[]> GeneratePdf(List<UrgentRequest> urgentRequests, DateTime fromDate, DateTime toDate)

        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                writer.Open();
                document.Open();

                CreateTable(urgentRequests, fromDate, toDate, document);

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


        private void CreateTable(List<UrgentRequest> urgentRequests, DateTime fromDate, DateTime toDate, Document document)
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



            foreach (UrgentRequest urgentRequest in urgentRequests)
            {

                PdfPCell cell_1 = new PdfPCell(new Phrase(""));

                //cell_1.Phrase.Add(_bankRepository.GetById(urgentRequest.BloodBankId).Name);
                cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell_1);

                CreateQuantityCell(table, urgentRequest, BloodType.A_POSITIVE);
                CreateQuantityCell(table, urgentRequest, BloodType.A_NEGATIVE);
                CreateQuantityCell(table, urgentRequest, BloodType.B_POSITIVE);
                CreateQuantityCell(table, urgentRequest, BloodType.B_NEGATIVE);
                CreateQuantityCell(table, urgentRequest, BloodType.AB_POSITIVE);
                CreateQuantityCell(table, urgentRequest, BloodType.AB_NEGATIVE);
                CreateQuantityCell(table, urgentRequest, BloodType.ZERO_POSITIVE);
                CreateQuantityCell(table, urgentRequest, BloodType.ZERO_NEGATIVE);

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

        private static void CreateQuantityCell(PdfPTable table, UrgentRequest urgentRequest, BloodType bloodType)
        {
            PdfPCell qCell = new PdfPCell(new Phrase(""));
            for (int i = 0; i < urgentRequest.Blood.Count; i++)
            {
                if (urgentRequest.Blood[i].BloodType.Equals(bloodType))
                {
                    qCell.Phrase.Add(urgentRequest.Blood[i].Quantity.ToString());
                    qCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    break;
                }
                else
                {
                    qCell.Phrase.Add("");
                    qCell.HorizontalAlignment = Element.ALIGN_CENTER;
                }
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


        public List<Blood> GetAllBloodAmountsBetweenDates(DateTime from, DateTime to)
        {
            List<Blood> bloods = initializeList();

            IEnumerable<Tender> tenders = _tenderRepository.GetAllBloodAmountsBetweenDates(from, to);

            foreach(Tender tender in tenders ) {
                foreach (Blood blood in tender.Blood) {
                    foreach (var bl in bloods.Where(x => x.BloodType.Equals(blood.BloodType)))
                        bl.Quantity = bl.Quantity + blood.Quantity;
                }
            }
            
            return bloods;
        }

        private List<Blood> initializeList()
        {
            List<Blood> bloods = new List<Blood>();
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.ZERO_POSITIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.A_POSITIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.B_POSITIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.ZERO_NEGATIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.AB_NEGATIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.AB_POSITIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.A_NEGATIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.B_NEGATIVE, 0));
            return bloods;
        }

    }
}
