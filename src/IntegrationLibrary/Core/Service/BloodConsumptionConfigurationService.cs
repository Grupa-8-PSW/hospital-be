using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public class BloodConsumptionConfigurationService : IBloodConsumptionConfigurationService
    {
        private readonly IBloodConsumptionConfigurationRepository _repository;
        
        public BloodConsumptionConfigurationService(IBloodConsumptionConfigurationRepository repo)
        {
            _repository = repo;
        }

        public BloodConsumptionConfiguration Create(BloodConsumptionConfiguration bloodConsumptionConfiguration)
        {
            return _repository.Create(bloodConsumptionConfiguration);
        }

        public List<BloodConsumptionConfiguration> GetAll()
        {
            return _repository.GetAll();
        }


        public BloodConsumptionConfiguration FindActiveConfiguration()
        {
            return _repository.FindActiveConfiguration();
        }


        public byte[] GeneratePdf(BloodConsumptionConfiguration bs, List<BloodUnit2> bloodUnits)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                writer.Open();

                document.Open();
                PdfPTable table = new PdfPTable(2);

                PdfPCell cell1 = new PdfPCell(new Phrase("Type", new Font(Font.FontFamily.HELVETICA, 10)));
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

                PdfPCell cell2 = new PdfPCell(new Phrase("Amount", new Font(Font.FontFamily.HELVETICA, 10)));
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



                Paragraph para1 = new Paragraph("Report for last: " + bs.ConsumptionPeriodHours.Days  + " days", new Font(Font.FontFamily.HELVETICA, 20));
                para1.Alignment = Element.ALIGN_CENTER;
                para1.SpacingAfter = 10;
                document.Add(para1);



                foreach (BloodUnit2 bloodUnit in bloodUnits)
                {

                    PdfPCell cell_1 = new PdfPCell(new Phrase(bloodUnit.BloodType.ToString()));
                    cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_1);

                    PdfPCell cell_2 = new PdfPCell(new Phrase(bloodUnit.AmountMl.ToString() + "ml"));
                    cell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_2);
                }

                document.Add(table);
                document.Close();
                writer.Close();
                var constant = ms.ToArray();

                return constant;


            }
        }


        public List<BloodUnit2> FindValidBloodUnits(List<BloodUnit2> bloodUnits, out List<BloodConsumptionConfiguration> configuration)
        {
            List<BloodUnit2> validList = new List<BloodUnit2>();
            configuration = _repository.GetAll();

            foreach (BloodUnit2 unit in bloodUnits)
            {
                if ((configuration.Last().NextSendingTime.Subtract(configuration.Last().ConsumptionPeriodHours) < unit.consumptionDate) &&
                    (unit.consumptionDate < configuration.Last().NextSendingTime))
                    validList.Add(unit);
            }

            return validList;
        }

        public void Update(BloodConsumptionConfiguration newBloodConsumptionConfiguration)
        {
            _repository.Update(newBloodConsumptionConfiguration);
        }

    }
}
