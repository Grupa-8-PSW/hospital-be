using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Prescription
    {
        public int Id { get; set; }
        public List<PrescriptionItem> PrescriptionItem { get; set; }

    }
}
