using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class BloodBankNewsMessageDTO
    {

        public string text { get; set; }
        public string subject { get; set; }

        public string imgSrc { get; set; }

        public string bloodBankApiKey { get; set; }

        public BloodBankNewsMessageDTO(string text, string subject, string imgSrc, string bloodBankApiKey)
        {
            this.text = text;
            this.subject = subject;
            this.imgSrc = imgSrc;
            this.bloodBankApiKey = bloodBankApiKey;
        }
        public BloodBankNewsMessageDTO()
        {

        }
    }
}
