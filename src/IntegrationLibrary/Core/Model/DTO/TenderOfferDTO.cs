using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class TenderOfferDTO
    {
        public int Id { get; set; }
        public int TenderID { get; set; } 
        public List<BloodOfferDTO> BloodAmounts { get; set; }
        public string BloodBankUsername { get; set; }
        public int TenderOfferStatus { get; set; }
    }
}
