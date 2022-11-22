using HospitalLibrary.Core.Model;
using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Util
{
    public interface ITreatmentReportGenerator
    {
        void AddInfo(ParagraphInfo paragraphInfo);
        void AddRecivedTherapy(ParagraphInfo bloodParagraphInfo, ParagraphInfo medicalDrugsParagraphInfo);
        Paragraph AddParagraph(ParagraphInfo paragraphInfo);
        void AddBloodTherapy();
        void AddMedicalDrugsTherapy();
        string RenderAndSaveReport(string dirName, string fileName);
        string GenerateSummarizingReport(TreatmentHistory treatmentHistory, string dirName, string fileName);
    }
}
