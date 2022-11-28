using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Validation
{
    public interface ITherapyValidation
    {
        public bool ValidateMedicalDrug(string name, int amount);
        public bool ValidateBlood(string bloodType, int amount);
    }
}
