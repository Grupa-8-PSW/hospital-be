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
        public int Id { get; private set; }
        [Required]
        public List<BloodOffer> Offers { get; private set; }
        public string BloodBankName { get; private set; }
        public TenderOfferStatus TenderOfferStatus { get; private set; }
       
        public TenderOffer(int id, List<BloodOffer> offers, string bloodBankName, TenderOfferStatus tenderOfferStatus)
        {
            Id = id;
            Offers = offers;
            BloodBankName = bloodBankName;
            TenderOfferStatus = tenderOfferStatus;
        }

        public TenderOffer()
        {
        }

        internal void Reject()
        {
            TenderOfferStatus = TenderOfferStatus.REJECT;
        }

        internal void Accept()
        {
            TenderOfferStatus = TenderOfferStatus.APPROVE;
        }
    }
}
