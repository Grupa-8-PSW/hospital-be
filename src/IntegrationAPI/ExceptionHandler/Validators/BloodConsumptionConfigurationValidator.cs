using IntegrationAPI.ExceptionHandler.Exceptions;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace IntegrationAPI.ExceptionHandler.Validators
{
    public class BloodConsumptionConfigurationValidator
    {
        public static void Validate(BloodConsumptionReportDTO bcrDTO)
        {
            if (bcrDTO == null)
            {
                throw new BloodConsumptionConfigurationArgumentException($"{nameof(bcrDTO)} is null.");
            }

            else if (string.IsNullOrWhiteSpace(bcrDTO.StartDate))
            {
                throw new BloodBankArgumentException($"{nameof(bcrDTO.StartDate)} is Null/Empty/WhiteSpace.");
            }

            else if (string.IsNullOrWhiteSpace(bcrDTO.StartTime))
            {
                throw new BloodBankArgumentException($"{nameof(bcrDTO.StartTime)} is Null/Empty/WhiteSpace.");
            }

            else if (bcrDTO.FrequencyPeriodInHours == null || bcrDTO.FrequencyPeriodInHours == 0) 
            {
                throw new BloodBankArgumentException($"{nameof(bcrDTO.FrequencyPeriodInHours)} is Null/Empty/WhiteSpace.");
            }
            else if (bcrDTO.ConsumptionPeriodHours == null || bcrDTO.ConsumptionPeriodHours == 0)
            {
                throw new BloodBankArgumentException($"{nameof(bcrDTO.ConsumptionPeriodHours)} is Null/Empty/WhiteSpace.");
            }

            try
            {
                BloodConsumptionConfiguration bcc = new BloodConsumptionConfiguration(bcrDTO);

                var s = DateTime.Now;
                if(bcc.StartDateTime.CompareTo(DateTime.Now) != 1)
                {
                    throw new BloodBankArgumentException($"{nameof(bcrDTO.StartTime)} is wrong.");
                }

            }
            catch (Exception ex)
            {
                throw new BloodBankArgumentException($"Something went wrong..Not corectly data input.");
            }

        }

    }
}
