using IntegrationAPI.ExceptionHandler.Validators;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodConsumptionConfigurationController : ControllerBase
    {
        private readonly IBloodConsumptionConfigurationService _service;

        public BloodConsumptionConfigurationController(IBloodConsumptionConfigurationService service)
        {
            _service = service;
        }

        
        [HttpPost]
        public BloodConsumptionConfiguration CreateConfiguration([FromBody] BloodConsumptionReportDTO dto)
        {
            return _service.Create(new BloodConsumptionConfiguration()
            {
                ConsumptionPeriodHours = dto.ConsumptionPeriodHours,
                FrequencyPeriodInHours = dto.FrequencyPeriodInHours,
                StartDate = dto.StartDate,
                StartTime = dto.StartTime
            });

        }

        [Route("/api/[controller]/generatePdf")]
        [HttpPost]
        public IActionResult GeneratePdf()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();
                PdfPTable table = new PdfPTable(2);

                PdfPCell cell1 = new PdfPCell(new Phrase("Type", new Font(Font.FontFamily.HELVETICA, 10)));
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
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
                cell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell2.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER |
                               Rectangle.RIGHT_BORDER;
                cell2.BorderWidthBottom = 1f;
                cell2.BorderWidthTop = 1f;
                cell2.BorderWidthLeft = 1f;
                cell2.BorderWidthRight = 1f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell2);
                

                List<BloodConsumptionConfiguration> bloodConsumptionConfigurations = _service.GetAll();
                
                
                Paragraph para1 = new Paragraph("Report for last: " + bloodConsumptionConfigurations[0].ConsumptionPeriodHours + " hours", new Font(Font.FontFamily.HELVETICA, 20));
                para1.Alignment = Element.ALIGN_CENTER;
                para1.SpacingAfter = 10;
                document.Add(para1);
                
                

                for (int i = 0; i < 8; i++)
                {

                    PdfPCell cell_1 = new PdfPCell(new Phrase("Grupa: " + i ));
                    cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_1);

                    PdfPCell cell_2 = new PdfPCell(new Phrase(i + 1.ToString()));
                    cell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_2);
                }

                document.Add(table);
                document.Close();
                writer.Close();
                var constant = ms.ToArray();

                return File(constant, "application/vnd", "bloodconsumptionreport.pdf");


            }
        }
    }
}
