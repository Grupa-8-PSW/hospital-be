using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Util;
using Shouldly;

namespace HospitalTests.HospitalLibraryTests
{
    public class ExaminationReportGeneratorTests
    {

        [Fact]
        public void ExaminationReportGenerator_Generates_Examination_Report()
        {
            // Arrange
            var examinationDone = GetDummyExaminationDone();
            var fileName = $"ExaminationReport_{examinationDone.Id}.pdf";
            const string dirName = @"C:\\Temp\";
            var examinationReportGenerator = new ExaminationReportGenerator(examinationDone);

            // Act
            var fullPath = examinationReportGenerator.GenerateReport(dirName, fileName, true, true, true);

            // Assert
            fullPath.ShouldNotBeNull();
            File.Exists(fullPath).ShouldBe(true);
        }

        private static ExaminationDone GetDummyExaminationDone()
        {
            var examinationDone = new ExaminationDone
            {
                Id = 1,
                Record = "Patient has some problems with leg.",
                Prescriptions = new List<Prescription>(new[]
                {
                    new Prescription { Id = 1 },
                    new Prescription { Id = 2 }
                }),
                Symptoms = new List<Symptom>(new[]
                {
                    new Symptom { Id = 1, Name = "swelling" },
                    new Symptom { Id = 2, Name = "varicose veins" },
                    new Symptom { Id = 3, Name = "redness" }
                })
            };

            return examinationDone;
        }
    }

}
