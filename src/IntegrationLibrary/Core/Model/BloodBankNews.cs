using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class BloodBankNews
    {
        public string Text { get;   set; }
        public string Subject { get;  set; }
        public int Id { get;  set; }

        public string ImgSrc { get;  set; }

        public int BloodBankId { get;  set; }  

        public BloodBank BloodBank { get;  set; }

        public bool Published { get;   set;  }

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

        public BloodBankNews(string text, string subject, string imgSrc, bool published, bool archived, BloodBank bloodBank, int bloodBankId)
        {
            this.Text = text;
            this.Subject = subject;
            this.ImgSrc = imgSrc;
            this.Published = published;
            this.Archived = archived;
            this.BloodBank = bloodBank;
            this.BloodBankId = bloodBankId;
        }

        public BloodBankNews()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is BloodBankNews news &&
                   Text == news.Text &&
                   Subject == news.Subject &&
                   Id == news.Id &&
                   ImgSrc == news.ImgSrc &&
                   BloodBankId == news.BloodBankId &&
                   EqualityComparer<BloodBank>.Default.Equals(BloodBank, news.BloodBank) &&
                   Published == news.Published &&
                   Archived == news.Archived;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Text, Subject, Id, ImgSrc, BloodBankId, BloodBank, Published, Archived);
        }

        public void ArchiveNews()
        {
            this.Archived = true;
        }

        public void PublishNews()
        {
            this.Published = true;
        }
    }
}
