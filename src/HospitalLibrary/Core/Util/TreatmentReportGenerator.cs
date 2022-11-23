using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Util
{
    /// <summary>
    /// Generates summarizing report on the patient's treatment in form of PDF
    /// </summary>
    public class TreatmentReportGenerator : ITreatmentReportGenerator
    {
        public Document Document { get; private set; }
        public TreatmentHistory TreatmentHistory { get; private set; }

        public TreatmentReportGenerator(TreatmentHistory th) 
        {
            Document = PDFUtils.CreateDocumentWithSection("Treatment History Report");
            TreatmentHistory = th;
        }

        public void AddInfo(ParagraphInfo paragraphInfo)
        {
            Paragraph infoPar = AddParagraph(paragraphInfo);
            infoPar.AddLineBreak();
            infoPar.AddText("Patient: " + TreatmentHistory.Patient.FullName);
            infoPar.AddLineBreak();
            infoPar.AddLineBreak();
            infoPar.AddText("Admission Reason: " + TreatmentHistory.Reason);
            infoPar.AddLineBreak();
            infoPar.AddLineBreak();
            infoPar.AddText("Discharge Reason: " + TreatmentHistory.DischargeReason);
            infoPar.AddLineBreak();
            infoPar.AddLineBreak();
            infoPar.AddText("Treatment Started: " + TreatmentHistory.StartDate.ToString("dd/MM/yyyy"));
            infoPar.AddLineBreak();
            infoPar.AddLineBreak();
            infoPar.AddText("Treatment Finished: " + TreatmentHistory.EndDate.Value.ToString("dd/MM/yyyy"));
        }

        public void AddRecivedTherapy(ParagraphInfo bloodParagraphInfo, 
            ParagraphInfo medicalDrugsParagraphInfo)
        {
            AddParagraph(bloodParagraphInfo);
            AddBloodTherapy();
            AddParagraph(medicalDrugsParagraphInfo);
            AddMedicalDrugsTherapy();
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

        public void AddBloodTherapy()
        {
            var bloodTherapies = TreatmentHistory.Therapies.Where(therapy => therapy.TherapyType == TherapyType.BLOOD_THERAPY);
            if (!bloodTherapies.Any())
            {
                AddParagraph(new ParagraphInfo()
                {
                    Allignment = ParagraphAlignment.Left,
                    Name = "No blood therapies.",
                    BookmarkName = "Blood therapies",
                    Style = "Heading4",
                    SpaceAfter = "1cm",
                    FontColor = Color.Parse("#4169E1")
                });
                return;
            }
            string[] bloodTherapyColumns = { "Date Prescribed", "Amount",
                "BloodType", "Reason" };
            List<RowInfo> bloodRows = new List<RowInfo>();
            bloodRows = bloodTherapies.Select(therapy =>
            {
                string whenPrescribed = therapy.WhenPrescribed.ToString("dd/MM/yyyy");
                string amount = therapy.Amount.ToString();
                string bloodType = therapy.TherapySubject;
                string reason = therapy.Reason;
                string[] cellsText = { whenPrescribed, amount, bloodType, reason };
                return new RowInfo(cellsText);
            }).ToList();
            PDFUtils.DefineTable(Document, bloodTherapyColumns, bloodRows);
        }

        public void AddMedicalDrugsTherapy()
        {
            var medicalDrugsTherapies = TreatmentHistory.Therapies.Where(therapy => therapy.TherapyType == TherapyType.MEDICAL_DRUG_THERAPY);
            if (!medicalDrugsTherapies.Any())
            {
                AddParagraph(new ParagraphInfo()
                {
                    Allignment = ParagraphAlignment.Left,
                    Name = "No medical drugs therapies.",
                    BookmarkName = "Medical drugs therapies",
                    Style = "Heading4",
                    SpaceAfter = "1cm",
                    FontColor = Color.Parse("#4169E1")
                });
                return;
            }

            string[] medicalDrugsTherapyColumns = { "Date Prescribed", "Amount",
                "Drug Name", "Reason" };
            List<RowInfo> medicalDrugsRows = new List<RowInfo>();
            medicalDrugsRows = medicalDrugsTherapies.Select(therapy =>
            {
                string whenPrescribed = therapy.WhenPrescribed.ToString("dd/MM/yyyy");
                string amount = therapy.Amount.ToString();
                string drugName = therapy.TherapySubject;
                string reason = therapy.Reason;
                string[] cellsText = { whenPrescribed, amount, drugName, reason };
                return new RowInfo(cellsText);
            }).ToList();
            PDFUtils.DefineTable(Document, medicalDrugsTherapyColumns, medicalDrugsRows);
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

        /// <summary>
        /// Generates summarizing report for treatment history in pdf format
        /// </summary>
        /// <param name="treatmentHistory"></param>
        /// <param name="dirName"></param>
        /// <param name="fileName"></param>
        /// <returns>Path to generated pdf</returns>
        public string GenerateSummarizingReport(TreatmentHistory treatmentHistory,
            string dirName,
            string fileName)
        {
            AddParagraph(new ParagraphInfo()
            {
                Allignment = ParagraphAlignment.Center,
                Name = "Treatment History Report",
                BookmarkName = "Treatment History Report",
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
                FontColor = Color.Parse("#4169E1")
            });
            this.AddParagraph(new ParagraphInfo()
            {
                Allignment = ParagraphAlignment.Center,
                Name = "Recived Therapies",
                BookmarkName = "Recived Therapies",
                Style = "Heading2",
                FontSize = 24,
                SpaceAfter = "1cm"
            });
            AddParagraph(new ParagraphInfo()
            {
                Allignment = ParagraphAlignment.Left,
                Name = "Blood",
                BookmarkName = "Blood",
                Style = "Heading3",
                FontColor = Color.Parse("#4169E1")
            });
            AddBloodTherapy();

            AddParagraph(new ParagraphInfo()
            {
                Allignment = ParagraphAlignment.Left,
                Name = "Medical Drugs",
                BookmarkName = "Medical Drugs",
                Style = "Heading3",
                SpaceBefore = "1cm",
                FontColor = Color.Parse("#4169E1")
            });
            AddMedicalDrugsTherapy();

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
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

    }
}
