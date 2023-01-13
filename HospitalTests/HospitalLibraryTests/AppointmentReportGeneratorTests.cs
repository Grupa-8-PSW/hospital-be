using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Util;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalLibraryTests
{
    public class AppointmentReportGeneratorTests
    {
        [Fact]
        public void GeneratesAppointmentReport()
        {
            // Arrange
            var examination = GetExamination();
            var doctor = GetDoctor();
            var patient= GetPatient();
            AppointmentReportGenerator appointmentReportGenerator = new AppointmentReportGenerator(examination, patient, doctor);
            string fileName = "appointment " + examination.Id + "_report.pdf";
            string dirName = @"C:\\Temp\";
            // Act
            var fullPath = appointmentReportGenerator.GenerateSummarizingReport(examination, dirName,fileName);

            // Assert
            fullPath.ShouldNotBe(null);
            File.Exists(fullPath).ShouldBe(true);
        }
        private static Examination GetExamination()
        {
            var start = "5/1/2022 8:30:00 AM";
            var end = "5/1/2022 9:00:00 AM";
            var examination = new Examination
            {
                Id = 1,
                PatientId = 1,
                DoctorId = 1,
                DateRange = new DateRange(DateTime.Parse(start), DateTime.Parse(end))                
                
            };
            return examination;
        }
        private static Patient GetPatient()
        {
            var patient = new Patient
            {
               FirstName="Marko",
               LastName="Filipovic"

            };
            return patient;
        }
        private static Doctor GetDoctor()
        {
            var doctor= new Doctor
            {
                FirstName="Filip",
                LastName="Markovic"

            };
            return doctor;
        }
    }
}
