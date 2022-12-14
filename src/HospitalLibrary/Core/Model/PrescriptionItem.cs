using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class PrescriptionItem
    {
        public int Id { get; set; }
        public int MedicalDrugId { get; set; }
        public MedicalDrugs MedicalDrug { get; set; }
        public int Quantity { get; set; }

    }
}