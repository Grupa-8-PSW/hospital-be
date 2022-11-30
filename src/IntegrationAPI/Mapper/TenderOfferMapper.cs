using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model.ValueObject;

namespace IntegrationAPI.Mapper
{
    public static class TenderOfferMapper
    {

        public static TenderOffer ToModel(TenderOfferDTO dto)
        {
            TenderOffer to = new TenderOffer();
            to.TenderID = dto.TenderID;
            to.Offers = convBloodOffers(dto.BloodAmounts);

            return to;
        }

        public static List<BloodOffer> convBloodOffers(List<BloodOfferDTO> dtos)
        {
            List<BloodOffer> convBloodOffers = new List<BloodOffer>();

            foreach (BloodOfferDTO dto in dtos)
            {
                convBloodOffers.Add(new BloodOffer(dto.BloodType, dto.BloodAmount, dto.PriceAmount));
            }

            return convBloodOffers;
        }

    }
}
