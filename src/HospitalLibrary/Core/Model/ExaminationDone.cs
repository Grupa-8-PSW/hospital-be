using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class ExaminationDone
    {
        public int Id { get; set; }
        public int ExaminationId { get; set; }
        public Examination Examination { get; set; }
        public List<Symptom> Symptoms { get; set; }
        public string Record { get; set; }
        public List<Prescription> Prescriptions { get; set; }

       
    }
}
