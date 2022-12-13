using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using BloodDTO = IntegrationLibrary.Core.Model.DTO.BloodDTO;

namespace IntegrationAPI.Mapper
{
    public static class MonthlySubscriptionMapper
    {
        public static MonthlySubscriptionDTO ToDTO(MonthlySubscription monthlySubscription)
        {
            MonthlySubscriptionDTO monthlySubscriptionDTO = new MonthlySubscriptionDTO();
            monthlySubscriptionDTO.BloodBankAPIKey = monthlySubscription.Bank.APIKey;
            List<BloodDTO> bloodDTOList = new List<BloodDTO>();
            foreach(IntegrationLibrary.Core.Model.Blood blood in monthlySubscription.RequestedBlood)
            {
                BloodDTO bloodDTO = new BloodDTO();
                BloodType bloodType = blood.BloodType;
                bloodDTO.Type = Enum.GetName(bloodType.GetType(), bloodType);
                bloodDTO.Quantity = blood.Quantity;
                bloodDTOList.Add(bloodDTO);
            }
            monthlySubscriptionDTO.RequestedBlood = bloodDTOList;
            monthlySubscriptionDTO.DeliveryDate = monthlySubscription.DeliveryDate;
            return monthlySubscriptionDTO;
        }
    }
}
