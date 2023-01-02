using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using MigraDoc.DocumentObjectModel;

namespace HospitalLibrary.Core.Util
{
    public class ExaminationReportGenerator
    {
        public Document Document { get; set; }
        public ExaminationDone ExaminationDone { get; set; }

        public ExaminationReportGenerator(ExaminationDone examinationDone)
        {
            Document = PDFUtils.CreateDocumentWithSection("Examination Report");
            ExaminationDone = examinationDone;
        }

        public Paragraph AddParagraph(ParagraphInfo paragraphInfo)
        {
            var paragraph = PDFUtils.DefineParagraph(paragraphInfo, Document.LastSection);
            paragraph.Format.Font.Size = paragraphInfo.FontSize;
            paragraph.Format.SpaceAfter = paragraphInfo.SpaceAfter;
            paragraph.Format.SpaceBefore = paragraphInfo.SpaceBefore;
            paragraph.Format.Font.Color = paragraphInfo.FontColor;

            paragraph.AddLineBreak();

            return paragraph;
        }

        public void AddStatementSection(ParagraphInfo paragraphInfo)
        {
            var statementParagraph = AddParagraph(paragraphInfo);
            statementParagraph.AddLineBreak();
            statementParagraph.AddText(ExaminationDone.Record);
        }

        public void AddSymptomsSection()
        {
            if (!ExaminationDone.Symptoms.Any())
            {
                AddParagraph(new ParagraphInfo()
                {
                    Allignment = ParagraphAlignment.Left,
                    Name = "No symptoms.",
                    BookmarkName = "Symptoms",
                    Style = "Heading4",
                    SpaceAfter = "1cm",
                    FontColor = Color.Parse("#4169E1")
                });
                return;
            }
            AddParagraph(new ParagraphInfo()
            {
                Allignment = ParagraphAlignment.Center,
                Name = "Symptoms",
                BookmarkName = "Symptoms",
                Style = "Heading2",
                FontSize = 24,
                SpaceAfter = "1cm"
            });
            string[] symptomColumns = { "Number", "Name" };
            var symptomRows = new List<RowInfo>();
            symptomRows = ExaminationDone.Symptoms.Select(s =>
            {
                return new RowInfo(new[]
                {
                    s.Id.ToString(),
                    s.Name
                });
            }).ToList();
            PDFUtils.DefineTable(Document, symptomColumns, symptomRows);
        }

        public void AddPrescriptionsSection()
        {
            if (!ExaminationDone.Prescriptions.Any())
            {
                AddParagraph(new ParagraphInfo()
                {
                    Allignment = ParagraphAlignment.Left,
                    Name = "No prescriptions.",
                    BookmarkName = "Prescriptions",
                    Style = "Heading4",
                    SpaceAfter = "1cm",
                    FontColor = Color.Parse("#4169E1"),
                    SpaceBefore = "1cm"
                });
                return;
            }
            AddParagraph(new ParagraphInfo()
            {
                Allignment = ParagraphAlignment.Center,
                Name = "Prescriptions",
                BookmarkName = "Prescriptions",
                Style = "Heading2",
                FontSize = 24,
                SpaceAfter = "1cm",
                SpaceBefore = "1cm"
            });
            string[] prescriptionColumns = { "Number", "Medical Drug", "Quantity" };
            var prescriptionRows = new List<RowInfo>();
            prescriptionRows = ExaminationDone.Prescriptions.Select(p =>
            {
                var medicalDrugNames = p.PrescriptionItem.Select(pi =>
                    pi.MedicalDrug.Name + ' ' + pi.MedicalDrug.Amount + "mg \n");
                var quantities = p.PrescriptionItem.Select(pi =>
                    pi.Quantity.ToString() + '\n');
                return new RowInfo(new[]
                {
                    p.Id.ToString(),
                    string.Join(' ', medicalDrugNames),
                    string.Join(' ', quantities)
                });
            }).ToList();
            PDFUtils.DefineTable(Document, prescriptionColumns, prescriptionRows);
        }

        public string RenderAndSaveReport(string dirName, string fileName)
        {
            var fullPath = dirName + fileName;
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

        public string? GenerateReport(string dirName, string fileName,
            bool showReport, bool showSymptoms, bool showPrescriptions)
        {
            AddParagraph(new ParagraphInfo()
            {
                Allignment = ParagraphAlignment.Center,
                Name = "Examination Report",
                BookmarkName = "Examination Report",
                Style = "Heading1",
                FontSize = 36,
                SpaceAfter = "2cm"
            });
            if (showReport)
            {
                AddStatementSection(new ParagraphInfo
                {
                    Allignment = ParagraphAlignment.Left,
                    Name = "Statement",
                    BookmarkName = "Statement Section",
                    Style = "Heading2",
                    SpaceAfter = "1cm",
                    FontColor = Color.Parse("#4169E1")
                });
            }
            if (showSymptoms)
            {
                AddSymptomsSection();
            }

            if (showPrescriptions)
            {
                AddPrescriptionsSection();
            }
            AddParagraph(new ParagraphInfo()
            {
                Allignment = ParagraphAlignment.Center,
                Name = DateTime.Now.ToString("dd/MM/yyyy"),
                BookmarkName = "Generated",
                Style = "Heading2",
                SpaceBefore = "1.5cm"
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
