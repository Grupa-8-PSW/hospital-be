using IntegrationLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public interface IBloodUnitRequestRepository
    {
        IEnumerable<BloodUnitRequest> GetAll();
        BloodUnitRequest GetById(int id);
        void Create(BloodUnitRequest bloodUnitRequest);
    }
}
