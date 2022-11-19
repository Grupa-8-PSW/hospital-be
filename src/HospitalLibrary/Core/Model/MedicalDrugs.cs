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
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public MedicalDrugs()
        {
        }

        public MedicalDrugs(int id, string code, string name, int amount)
        {
            Id = id;
            Code = code;
            Name = name;
            Amount = amount;
        }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }
}
