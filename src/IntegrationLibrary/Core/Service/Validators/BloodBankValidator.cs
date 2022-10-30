using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Validators
{
    public static class BloodBankValidator
    {
        public static void Validate(BloodBankDTO bb)
        {
            if (bb == null)
            {
                throw new BloodBankArgumentException($"{nameof(bb)} is null.");
            }

            else if (string.IsNullOrWhiteSpace(bb.Email))
            {
                throw new BloodBankArgumentException($"{nameof(bb.Email)} is Null/Empty/WhiteSpace.");
            }

            
            else if (string.IsNullOrWhiteSpace(bb.Name))
            {
                throw new BloodBankArgumentException($"{nameof(bb.Name)} is Null/Empty/WhiteSpace.");
                 
            }

            else if (string.IsNullOrWhiteSpace(bb.ServerAddress))
            {
                throw new BloodBankArgumentException($"{nameof(bb.ServerAddress)} is Null/Empty/WhiteSpace.");
            }
            
            else if (bb.Email.Length > 0)
            {
                Regex emailRegex = new Regex("@(([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]*\\.)+[a-zA-Z0-9]{2,17})$");
                if (!emailRegex.IsMatch(bb.Email))
                {
                    throw new BloodBankArgumentException($"{nameof(bb.Email)} is invalid.");
                }
            }

        }
    }
}
