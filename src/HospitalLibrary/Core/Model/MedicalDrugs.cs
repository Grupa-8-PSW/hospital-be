using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class MedicalDrugs
    {
        public string Name { get; set; }
        public MedicalDrugType Type {get; set;}

        public MedicalDrugs()
        {
        }

        public MedicalDrugs(string name, MedicalDrugType type)
        {
            Name = name;
            Type = type;
        }
    }
}
