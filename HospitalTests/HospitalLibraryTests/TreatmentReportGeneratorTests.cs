using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Util;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalLibraryTests
{
    public class TreatmentReportGeneratorTests
    {
        [Fact]
        public void Generates_treatment_report()
        {
            TreatmentHistory treatmentHistory = GetDummyTreatmentHistory();
            string fileName = treatmentHistory.Patient.Id
               + "_"
               + treatmentHistory.Patient.FirstName
               + treatmentHistory.Patient.LastName
               + "_report.pdf";
            string dirName = @"C:\\Temp\";
            TreatmentReportGenerator treatmentReportGenerator = new TreatmentReportGenerator(treatmentHistory);

            treatmentReportGenerator.GenerateSummarizingReport(treatmentHistory, dirName, fileName);

            File.Exists(@"C:\\Temp\" + fileName).ShouldBeTrue();
        }

        private TreatmentHistory GetDummyTreatmentHistory()
        {
            TreatmentHistory th = new TreatmentHistory()
            {
                Id = 1,
                Active = false,
                Bed = null,
                Reason = "Headache",
                DischargeReason = "Patient recovered.",
                StartDate = new DateTime(2022, 10, 15),
                EndDate = new DateTime(2022, 11, 17),
                BedId = 1,
                Patient = GetDummyPatient(),
                Therapies = GetDummyTherapies()
            };

            return th;
        }

        private Patient GetDummyPatient()
        {
            Patient patient1 = new Patient()
            {
                Id = 1,
                FirstName = "Dragan",
                LastName = "Kovacevic",
            };

            return patient1;

        }

        private List<Therapy> GetDummyTherapies()
        {
            Therapy t1 = new Therapy()
            {
                Id = 1,
                Amount = 2,
                TherapyType = TherapyType.MEDICAL_DRUG_THERAPY,
                TherapySubject = "Bromazepam 500mg",
                Reason = "Headache",
                WhenPrescribed = new DateTime(2022, 11, 2),
            };

            Therapy t2 = new Therapy()
            {
                Id = 2,
                Amount = 1,
                TherapyType = TherapyType.BLOOD_THERAPY,
                TherapySubject = "A+ 500ml",
                Reason = "Blood loss",
                WhenPrescribed = new DateTime(2022, 11, 8),
            };
            List<Therapy> therapies = new List<Therapy>();
            therapies.Add(t1);
            therapies.Add(t2);

            return therapies;
        }
    }
}
