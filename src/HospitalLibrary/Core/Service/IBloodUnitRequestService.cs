using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IBloodUnitRequestService
    {
        IEnumerable<BloodUnitRequest> GetAll();
        BloodUnitRequest GetById(int id);
        bool Create(BloodUnitRequest bloodUnitRequest);
        void Update(BloodUnitRequest bloodUnitRequest);
    }
}
