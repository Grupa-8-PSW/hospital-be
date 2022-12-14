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
        private int v1;
        private List<BloodOffer> bloodOffers;
        private string v2;
        private TenderOfferStatus wAITING;

        public int Id { get; set; }
        [Required]
        public int TenderID { get; set; }
        [Required]
        public List<BloodOffer> Offers { get; set; }
        public string BloodBankName { get; set; }
        public TenderOfferStatus TenderOfferStatus { get; set; }
       
        public TenderOffer(int id, int tenderID, List<BloodOffer> offers, string bloodBankName, TenderOfferStatus tenderOfferStatus)
        {
            Id = id;
            TenderID = tenderID;
            Offers = offers;
            BloodBankName = bloodBankName;
            TenderOfferStatus = tenderOfferStatus;
        }

        public TenderOffer()
        {
        }

        public TenderOffer(int v1, List<BloodOffer> bloodOffers, string v2, TenderOfferStatus wAITING)
        {
            this.v1 = v1;
            this.bloodOffers = bloodOffers;
            this.v2 = v2;
            this.wAITING = wAITING;
        }
    }
}
