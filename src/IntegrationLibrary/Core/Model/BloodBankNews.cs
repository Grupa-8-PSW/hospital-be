using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class BloodBankNews
    {
        public string Text { get; set; }
        public string Subject { get; set; }
        public int Id { get; set; }

        public string ImgSrc { get; set; }

        public int BloodBankId { get; set; }  

        public BloodBank BloodBank { get; set; }

        public bool Published { get; set; }

        public bool Archived { get; set; }

        public BloodBankNews(string text, string subject, int id, string imgSrc, bool published, bool archived, BloodBank bloodBank, int bloodBankId)
        {
            this.Text = text;
            this.Subject = subject;
            this.Id = id;
            this.ImgSrc = imgSrc;
            this.Published = published;
            this.Archived = archived;
            this.BloodBank = bloodBank;
            this.BloodBankId = bloodBankId;
        }

        public BloodBankNews()
        {
        }
    }
}
