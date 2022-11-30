using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model.DTO;

namespace IntegrationLibrary.Core.Model
{
    public class BloodUnitUrgentRequest
    {

        public int Id { get; set; }
        public List<BloodDTO> bloodUnits { get; set; }
        public string APIKey { get; set; }

        public BloodUnitUrgentRequest(int id, List<BloodDTO> bloodUnits, string apiKey)
        {
            this.Id = id;
            this.bloodUnits = bloodUnits;
            this.APIKey = apiKey;
        }

        public BloodUnitUrgentRequest()
        {
        }


    }
}
