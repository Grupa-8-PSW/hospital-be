using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model.DTO
{
    public class BloodBankNewsDTO
    {
        public string Text { get; set; }
        public string Subject { get; set; }
        public int Id { get; set; }

        public string ImgSrc { get; set; }

        public int BloodBankId { get; set; }

        public BloodBank BloodBank { get; set; }

        public bool Published { get; set; }

        public bool Archived { get; set; }
    }
}
