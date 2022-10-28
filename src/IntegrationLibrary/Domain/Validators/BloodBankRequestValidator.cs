using System.Text.RegularExpressions;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Domain.Exceptions;

namespace IntegrationAPI.Domain.Validators
{
    public static class BloodBankRequestValidator
    {
        public static void Validate(BloodBank bloodBank)
        {
            if (bloodBank == null)
            {
                throw new BloodBankArgumentException($"{nameof(bloodBank)} is null");
            }
            else if (string.IsNullOrWhiteSpace(bloodBank.Name))
            {
                throw new BloodBankArgumentException($"{nameof(bloodBank.Name)} is Null/Empty/Whitespace");
            }
            else if (string.IsNullOrWhiteSpace(bloodBank.ServerAddress))
            {
                throw new BloodBankArgumentException($"{nameof(bloodBank.ServerAddress)} is Null/Empty/Whitespace");
            }
            else if (string.IsNullOrWhiteSpace(bloodBank.Email))
            {
                throw new BloodBankArgumentException($"{nameof(bloodBank.Email)} is Null/Empty/Whitespace");
            }
            else if (bloodBank.Email.Length > 0)
            {
                Regex emailRegex = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
                if (!emailRegex.IsMatch(bloodBank.Email))
                {
                    throw new BloodBankArgumentException($"{nameof(bloodBank.Email)} is invalid");
                }
            }
        }
    }
}
