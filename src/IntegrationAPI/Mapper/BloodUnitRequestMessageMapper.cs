using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model.DTO;

namespace IntegrationAPI.Mapper
{
    public static class BloodUnitRequestMessageMapper
    {
        public static BloodUnitRequestMessageDTO ToMessage(BloodUnitRequestDTO bloodUnitRequestDTO)
        {
            BloodUnitRequestMessageDTO bloodUnitRequestMessageDTO = new BloodUnitRequestMessageDTO();
            bloodUnitRequestMessageDTO.hospitalRequestId = bloodUnitRequestDTO.Id;
            bloodUnitRequestMessageDTO.amountL = bloodUnitRequestDTO.AmountL;
            BloodType bloodType;
            if (!Enum.TryParse<BloodType>(bloodUnitRequestDTO.Type, out bloodType))
            {
                bloodUnitRequestMessageDTO.type = "";
            }

            bloodUnitRequestMessageDTO.type = Enum.GetName(bloodType.GetType(), bloodType);
            bloodUnitRequestMessageDTO.deliveryDate = bloodUnitRequestDTO.CreationDate;
            return bloodUnitRequestMessageDTO;
        }

    }
}
