using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;

namespace IntegrationLibrary.Core.Service
{
    public class BloodService : IBloodService {



        public BloodService()
        {
        }


        public List<BloodDTO> GetMissingQuantities(List<BloodDTO> bloodInStorage)
        {
            List<BloodDTO> missingQuinitites = new List<BloodDTO>();
            foreach (BloodDTO bloodUnit in bloodInStorage)
            {
                if (bloodUnit.Quantity < 1000)
                {
                    BloodDTO newBlood = new BloodDTO();
                    newBlood.Id = bloodUnit.Id;
                    newBlood.Quantity = 1000 - bloodUnit.Quantity;
                    newBlood.Type = bloodUnit.Type;
                    missingQuinitites.Add(newBlood);
                }

            }

            return missingQuinitites;
        }
    }
}
