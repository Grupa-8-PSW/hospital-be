using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Therapy
    {
        public int Id { get; set; }
        public DateTime WhenPrescribed { get; set; }
        public int Amount { get; set; }
        public string Reason { get; set; }
        public int PrescribedId { get; set; }
        [NotMapped]
        public ITherapySubject Prescribed { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public Therapy()
        {
        }

        public Therapy(DateTime whenPrescribed, int amount, string reason, int prescribedId, ITherapySubject prescribed, int doctorId, Doctor doctor)
        {
            WhenPrescribed = whenPrescribed;
            Amount = amount;
            Reason = reason;
            PrescribedId = prescribedId;
            Prescribed = prescribed;
            DoctorId = doctorId;
            Doctor = doctor;
        }
    }
}
