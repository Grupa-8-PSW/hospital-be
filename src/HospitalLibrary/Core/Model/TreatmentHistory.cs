using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class TreatmentHistory
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public string DischargeReason { get; set; }
        public IEnumerable<Therapy> Therapies { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int BedId { get; set; }
        public Bed Bed { get; set; }

        public TreatmentHistory()
        {
        }

        public TreatmentHistory(DateTime startDate, DateTime endDate, bool active, string dischargeReason, IEnumerable<Therapy> therapies, int patientId, Patient patient, int bedId, Bed bed)
        {
            StartDate = startDate;
            EndDate = endDate;
            Active = active;
            DischargeReason = dischargeReason;
            Therapies = therapies;
            PatientId = patientId;
            Patient = patient;
            BedId = bedId;
            Bed = bed;
        }
    }
}
