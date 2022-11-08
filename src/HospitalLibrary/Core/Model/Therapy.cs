using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Therapy
    {
        DateTime WhenPrescribed { get; set; }
        int Amount { get; set; }
        string Reason { get; set; }
        ITherapySubject Prescribed { get; set; }
        Doctor Doctor { get; set; }

        public Therapy()
        {
        }

        public Therapy(DateTime whenPrescribed, int amount, string reason, ITherapySubject prescribed, Doctor doctor)
        {
            WhenPrescribed = whenPrescribed;
            Amount = amount;
            Reason = reason;
            Prescribed = prescribed;
            Doctor = doctor;
        }
    }
}
