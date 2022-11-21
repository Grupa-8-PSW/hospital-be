using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class BloodUnitRequest
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public string Reason { get; set; }
        public DateTime CreationDate { get; set; }

        public BloodUnitRequest()
        {
        }

        public BloodUnitRequest(int id, string type, int amount, string reason, DateTime creationDate)
        {
            Id = id;
            Type = type;
            Amount = amount;
            Reason = reason;
            CreationDate = creationDate;
        }
    }
}

