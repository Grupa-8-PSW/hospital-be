using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class BloodUnitService : IBloodUnitService
    {
        private readonly IBloodUnitRepository _bloodUnitRepositoryRepo;

        public BloodUnitService(IBloodUnitRepository bloodUnitRepository)
        {
            this._bloodUnitRepositoryRepo = bloodUnitRepository;
        }
        public IEnumerable<BloodUnit> GetAll()
        {
            return _bloodUnitRepositoryRepo.GetAll();
        }
    }
}
