using IntegrationLibrary.Core.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class UrgentRequest
    {
        public int Id { get; set; }
        public int BloodBankId { get;  set; }
        public DateTime ObtainedDate { get;  set; }
        public List<Blood> Blood { get;  set; }

        public UrgentRequest(int bloodBankId, DateTime obtainedDate, List<Blood> blood)
        {
            BloodBankId = bloodBankId;
            Blood = blood;
            ObtainedDate = obtainedDate;
        }

        public UrgentRequest()
        {
        }
    }
}
