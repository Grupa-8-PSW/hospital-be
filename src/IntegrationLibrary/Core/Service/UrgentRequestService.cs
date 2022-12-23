using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Core.Service.Interfaces;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Auth;
using Firebase.Storage;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;

namespace IntegrationLibrary.Core.Service
{
    public class UrgentRequestService : IUrgentRequestService
    {
        private readonly IUrgentRequestRepository _urgentRequestRepository;
        private readonly IBloodBankRepository _bankRepository;
        public UrgentRequestService(IUrgentRequestRepository urgentRequestRepository, IBloodBankRepository bloodBankRepository) {
            _urgentRequestRepository = urgentRequestRepository;
            _bankRepository = bloodBankRepository;
        }

        public List<UrgentRequest> FindUrgentRequestsBetweenDates(DateTime fromDate, DateTime toDate)
        {
            List<UrgentRequest> validRequests = new List<UrgentRequest>();
            foreach(UrgentRequest urgentRequest in (List<UrgentRequest>)_urgentRequestRepository.GetAll())
            {
                if (fromDate.Ticks < urgentRequest.ObtainedDate.Ticks && urgentRequest.ObtainedDate.Ticks < toDate.Ticks)
                    validRequests.Add(urgentRequest);
            }
            if(validRequests.Count == 0)
                Console.WriteLine("Za ovaj period nema nabavljene krvi");

            return validRequests;
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

                }catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                return constant;
            }
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

        private void CreateTable(List<UrgentRequest> urgentRequests, DateTime fromDate, DateTime toDate, Document document)
        {
            PdfPTable table = new PdfPTable(9);


            PdfPCell cell = new PdfPCell(new Phrase("Blood Bank name", new Font(Font.FontFamily.HELVETICA, 10)));
            cell.BackgroundColor = BaseColor.PINK;
            cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                           Rectangle.RIGHT_BORDER;
            cell.BorderWidthBottom = 1f;
            cell.BorderWidthTop = 1f;
            cell.BorderWidthLeft = 1f;
            cell.BorderWidthRight = 1f;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);


            PdfPCell cell1 = new PdfPCell(new Phrase("A+", new Font(Font.FontFamily.HELVETICA, 10)));
            cell1.BackgroundColor = BaseColor.PINK;
            cell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                           Rectangle.RIGHT_BORDER;
            cell1.BorderWidthBottom = 1f;
            cell1.BorderWidthTop = 1f;
            cell1.BorderWidthLeft = 1f;
            cell1.BorderWidthRight = 1f;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            cell1.VerticalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell1);

            PdfPCell cell2 = new PdfPCell(new Phrase("A-", new Font(Font.FontFamily.HELVETICA, 10)));
            cell2.BackgroundColor = BaseColor.PINK;
            cell2.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                           Rectangle.RIGHT_BORDER;
            cell2.BorderWidthBottom = 1f;
            cell2.BorderWidthTop = 1f;
            cell2.BorderWidthLeft = 1f;
            cell2.BorderWidthRight = 1f;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell2);

            PdfPCell cell3 = new PdfPCell(new Phrase("B+", new Font(Font.FontFamily.HELVETICA, 10)));
            cell3.BackgroundColor = BaseColor.PINK;
            cell3.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                           Rectangle.RIGHT_BORDER;
            cell3.BorderWidthBottom = 1f;
            cell3.BorderWidthTop = 1f;
            cell3.BorderWidthLeft = 1f;
            cell3.BorderWidthRight = 1f;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            cell3.VerticalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell3);

            PdfPCell cell4 = new PdfPCell(new Phrase("B-", new Font(Font.FontFamily.HELVETICA, 10)));
            cell4.BackgroundColor = BaseColor.PINK;
            cell4.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                           Rectangle.RIGHT_BORDER;
            cell4.BorderWidthBottom = 1f;
            cell4.BorderWidthTop = 1f;
            cell4.BorderWidthLeft = 1f;
            cell4.BorderWidthRight = 1f;
            cell4.HorizontalAlignment = Element.ALIGN_CENTER;
            cell4.VerticalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell4);

            PdfPCell cell5 = new PdfPCell(new Phrase("AB+", new Font(Font.FontFamily.HELVETICA, 10)));
            cell5.BackgroundColor = BaseColor.PINK;
            cell5.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                           Rectangle.RIGHT_BORDER;
            cell5.BorderWidthBottom = 1f;
            cell5.BorderWidthTop = 1f;
            cell5.BorderWidthLeft = 1f;
            cell5.BorderWidthRight = 1f;
            cell5.HorizontalAlignment = Element.ALIGN_CENTER;
            cell5.VerticalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell5);

            PdfPCell cell6 = new PdfPCell(new Phrase("AB-", new Font(Font.FontFamily.HELVETICA, 10)));
            cell6.BackgroundColor = BaseColor.PINK;
            cell6.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                           Rectangle.RIGHT_BORDER;
            cell6.BorderWidthBottom = 1f;
            cell6.BorderWidthTop = 1f;
            cell6.BorderWidthLeft = 1f;
            cell6.BorderWidthRight = 1f;
            cell6.HorizontalAlignment = Element.ALIGN_CENTER;
            cell6.VerticalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell6);

            PdfPCell cell7 = new PdfPCell(new Phrase("O+", new Font(Font.FontFamily.HELVETICA, 10)));
            cell7.BackgroundColor = BaseColor.PINK;
            cell7.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                           Rectangle.RIGHT_BORDER;
            cell7.BorderWidthBottom = 1f;
            cell7.BorderWidthTop = 1f;
            cell7.BorderWidthLeft = 1f;
            cell7.BorderWidthRight = 1f;
            cell7.HorizontalAlignment = Element.ALIGN_CENTER;
            cell7.VerticalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell7);

            PdfPCell cell8 = new PdfPCell(new Phrase("O-", new Font(Font.FontFamily.HELVETICA, 10)));
            cell8.BackgroundColor = BaseColor.PINK;
            cell8.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                           Rectangle.RIGHT_BORDER;
            cell8.BorderWidthBottom = 1f;
            cell8.BorderWidthTop = 1f;
            cell8.BorderWidthLeft = 1f;
            cell8.BorderWidthRight = 1f;
            cell8.HorizontalAlignment = Element.ALIGN_CENTER;
            cell8.VerticalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell8);

            Paragraph para1 = new Paragraph("Report from date " + fromDate.Date + " to date " + toDate.Date, new Font(Font.FontFamily.HELVETICA, 20));
            para1.Alignment = Element.ALIGN_CENTER;
            para1.SpacingAfter = 10;
            document.Add(para1);

            foreach (UrgentRequest urgentRequest in urgentRequests)
            {

                PdfPCell cell_1 = new PdfPCell(new Phrase(""));
                cell_1.Phrase.Add(_bankRepository.GetById(urgentRequest.BloodBankId).Name);
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
    }
}
