using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model.ValueObject;
using Newtonsoft.Json;

namespace IntegrationLibrary.Core.Model
{
    public class TenderOffer
    {
        public int Id { get; set; }
        [Required]
        public int TenderID { get; set; }
        [Required]
        public List<BloodOffer> Offers { get; set; }
        public string BloodBankName { get; set; }
        public TenderOfferStatus TenderOfferStatus { get; set; }
       
        public TenderOffer(int id, int tenderID, List<BloodOffer> offers, string bloodBankName, TenderOffer tenderOfferStatus)
        {
            Id = id;
            TenderID = tenderID;
            Offers = offers;
            BloodBankName = bloodBankName;
            TenderOfferStatus = TenderOfferStatus;
        }

        public TenderOffer()
        {
        }
    }
}
