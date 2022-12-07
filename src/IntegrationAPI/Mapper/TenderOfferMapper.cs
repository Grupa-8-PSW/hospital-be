using HospitalLibrary.Core.Enums;
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
                convBloodOffers.Add(new BloodOffer(dto.BloodType, dto.BloodAmount, new Money(dto.PriceAmount, Currency.USD)));
            }

            return convBloodOffers;
        }


        public static List<BloodOfferDTO> convBloodOffersToDTO(List<BloodOffer> bos)
        {
            List<BloodOfferDTO> convBloodOffersDTO = new List<BloodOfferDTO>();

            foreach (BloodOffer bo in bos)
            {
                convBloodOffersDTO.Add(new BloodOfferDTO()
                {
                    BloodAmount = bo.BloodAmount,
                    BloodType = bo.BloodType,
                    PriceAmount = 0
                });
            }

            return convBloodOffersDTO;
        }

        internal static List<TenderOfferDTO> convertTenderTOBloodOffersDTO(IEnumerable<Tender> tenders)
        {
            List<TenderOfferDTO> convBloodOffersDTO = new List<TenderOfferDTO>();

            foreach(Tender tender in tenders)
            {
                convBloodOffersDTO.Add(new TenderOfferDTO()
                {
                    TenderID = tender.Id,
                    BloodAmounts = convFromTenderTOBloodAmounts(tender.Blood)
                }); 
            }

            return convBloodOffersDTO;
        }

        

        private static List<BloodOfferDTO> convFromTenderTOBloodAmounts(List<IntegrationLibrary.Core.Model.Blood> blood)
        {
            List<BloodOfferDTO> bos = new List<BloodOfferDTO>();

            foreach (IntegrationLibrary.Core.Model.Blood b in blood)
            {
                bos.Add(new BloodOfferDTO()
                {
                    BloodAmount = b.Quantity,
                    BloodType = BlootTypeToString(b.BloodType),
                    PriceAmount = 0
                }); ;
            }

            return bos;
        }

        private static string BlootTypeToString(BloodType bloodType)
        {
            if (bloodType == BloodType.ZERO_POSITIVE)
                return "0+";
            else if (bloodType == BloodType.ZERO_NEGATIVE)
                return "0-";
            else if (bloodType == BloodType.A_POSITIVE)
                return "A+";
            else if (bloodType == BloodType.A_NEGATIVE)
                return "A-";
            else if (bloodType == BloodType.B_NEGATIVE)
                return "B-";
            else if (bloodType == BloodType.B_POSITIVE)
                return "B+";
            else if (bloodType == BloodType.AB_NEGATIVE)
                return "AB-";
            else 
                return "AB+"; 
            
        }
    }
}
