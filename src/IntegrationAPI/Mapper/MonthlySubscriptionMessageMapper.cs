using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using BloodDTO = IntegrationLibrary.Core.Model.DTO.BloodDTO;

namespace IntegrationAPI.Mapper
{
    public static class MonthlySubscriptionMessageMapper
    {
        public static MonthlySubscriptionMessageDTO ToDTO(MonthlySubscription monthlySubscription)
        {
            MonthlySubscriptionMessageDTO monthlySubscriptionDTO = new MonthlySubscriptionMessageDTO();
            monthlySubscriptionDTO.BloodBankAPIKey = monthlySubscription.Bank.APIKey;
            List<BloodDTO> bloodDTOList = new List<BloodDTO>();
            foreach(IntegrationLibrary.Core.Model.ValueObject.Blood blood in monthlySubscription.RequestedBlood)
            {
                BloodDTO bloodDTO = new BloodDTO();
                BloodType bloodType = blood.BloodType;
                bloodDTO.Type = Enum.GetName(bloodType.GetType(), bloodType);
                bloodDTO.Quantity = blood.Quantity;
                bloodDTOList.Add(bloodDTO);
            }
            monthlySubscriptionDTO.HospitalSubscriptionId = monthlySubscription.Id;
            monthlySubscriptionDTO.RequestedBlood = bloodDTOList;
            monthlySubscriptionDTO.DeliveryDate = monthlySubscription.DeliveryDate.ToString("dd/MM/yyyy");
            return monthlySubscriptionDTO;
        }
    }
}
