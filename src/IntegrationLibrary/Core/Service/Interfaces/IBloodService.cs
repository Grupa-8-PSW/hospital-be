using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model.DTO;

namespace IntegrationLibrary.Core.Service.Interfaces
{
    public interface IBloodService
    {
        public List<BloodDTO> GetMissingQuantities(List<BloodDTO> bloodInStorage);
    }
}
