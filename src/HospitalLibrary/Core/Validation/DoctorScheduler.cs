using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Validation
{
    public class DoctorScheduler
    {
        public Doctor Doctor { get; set; }
        public DateTime WantedStartTime { get; set; }
        public int WantedDuration { get; set; }
        public List<Examination> ExaminationsForDate { get; set; }

        public DoctorScheduler(Doctor doctor, DateTime wantedStartTime, int wantedDuration, List<Examination> examinationsForDate)
        {
            Doctor = doctor;
            WantedStartTime = wantedStartTime;
            WantedDuration = wantedDuration;
            ExaminationsForDate = examinationsForDate;
        }
    }
}