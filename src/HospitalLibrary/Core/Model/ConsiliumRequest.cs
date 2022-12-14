using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class ConsiliumRequest
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateRange Interval { get; set; }
        public int Duration { get; set; }
        public bool IsDoctors { get; set; }
        public List<int>? DoctorIds { get; set; }
        public List<DoctorSpecialization>? DoctorSpecializationsWanted { get; set; }

        public ConsiliumRequest(int id, string subject, DateRange interval, int duration, bool isDoctors)
        {
            Id = id;
            Subject = subject;
            Interval = interval;
            Duration = duration;
            IsDoctors = isDoctors;
            Validate();
        }

        public ConsiliumRequest()
        {

        }

        private void Validate()
        {
            if (Duration < 0)
                throw new ArgumentException("Duration must be positive number");
        }
    }
}
