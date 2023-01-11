using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Util
{
    public class AppointmentReportGenerator
    {
        public Document Document { get; private set; }
        public Examination _examination { get; private set; }
        public Doctor _doctor { get; private set; }
        public Patient _patient { get; private set; }

        public AppointmentReportGenerator(Examination examination,Patient patient,Doctor doctor)
        {
            Document = PDFUtils.CreateDocumentWithSection("Examination report");
            _examination = examination;
            _doctor=doctor;
            _patient = patient;
        }
        public Paragraph AddParagraph(ParagraphInfo paragraphInfo)
        {
            Paragraph paragraph = PDFUtils.DefineParagraph(paragraphInfo, Document.LastSection);
            paragraph.Format.Font.Size = paragraphInfo.FontSize;
            paragraph.Format.SpaceAfter = paragraphInfo.SpaceAfter;
            paragraph.Format.SpaceBefore = paragraphInfo.SpaceBefore;
            paragraph.Format.Font.Color = paragraphInfo.FontColor;

            paragraph.AddLineBreak();

            return paragraph;
        }
        public void AddInfo(ParagraphInfo paragraphInfo)
        {
            Paragraph infoPar = AddParagraph(paragraphInfo);
            infoPar.AddLineBreak();
            infoPar.AddText("Patient: " + _patient.FullName);
            infoPar.AddLineBreak();
            infoPar.AddLineBreak();
            infoPar.AddText("Doctor: " +_doctor.FullName+","+_doctor.Specialization.ToString());
            infoPar.AddLineBreak();
            infoPar.AddLineBreak();
            infoPar.AddText("Start: " + _examination.DateRange.Start.ToString());
            infoPar.AddLineBreak();
            infoPar.AddText("Duration: " + _examination.DateRange.DurationInMinutes.ToString()+" minutes");
            infoPar.AddLineBreak();
            infoPar.AddLineBreak();
        }
        public string RenderAndSaveReport(string dirName, string fileName)
        {
            string fullPath = dirName + fileName;
            try
            {
                Directory.CreateDirectory(dirName);
                PDFUtils.RenderAndSaveDocument(Document, fullPath);
                return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new Exception("Failed to render and save report to path: " + fullPath);
            }

        }
        public string GenerateSummarizingReport(Examination examination,
            string dirName,
            string fileName)
        {
            AddParagraph(new ParagraphInfo()
            {
                Allignment = ParagraphAlignment.Center,
                Name = "Appointment Report",
                BookmarkName = "Appointment Report",
                Style = "Heading1",
                FontSize = 36,
                SpaceAfter = "2cm"
            });
            AddInfo(new ParagraphInfo()
            {
                Allignment = ParagraphAlignment.Left,
                Name = "",
                BookmarkName = "Informations",
                Style = "Heading2",
                SpaceAfter = "1cm",
                FontColor = MigraDoc.DocumentObjectModel.Color.Parse("#4169E1")
            });

            try
            {
                return RenderAndSaveReport(dirName, fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
    }
}
