using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class BloodBankNews
    {
        public string text { get; set; }
        public string subject { get; set; }
        public int id { get; set; }

        public byte[] byteArray { get; set; } = Array.Empty<byte>();

        public bool published { get; set; }

        public bool archived { get; set; }

        public BloodBankNews(string text, string subject, int id, byte[] byteArray, bool published, bool archived)
        {
            this.text = text;
            this.subject = subject;
            this.id = id;
            this.byteArray = byteArray;
            this.published = published;
            this.archived = archived;
        }

        public BloodBankNews()
        {
        }
    }
}
