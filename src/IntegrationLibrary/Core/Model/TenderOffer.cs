using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model.ValueObject;

namespace IntegrationLibrary.Core.Model
{
    public class tenderOfferDTO
    {
        public int Id { get; set; }
        [Required]
        public int TenderID { get; set; }          
        public List<BloodOffer> Offers { get; set; }


        public tenderOfferDTO()
        {
        }
    }
}
