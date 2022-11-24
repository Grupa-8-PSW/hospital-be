using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class BloodUnitRequestService : IBloodUnitRequestService
    {
        private readonly IBloodUnitRequestRepository _bloodUnitRequestRepository;

        public BloodUnitRequestService(IBloodUnitRequestRepository bloodUnitRequestRepository)
        {
            _bloodUnitRequestRepository = bloodUnitRequestRepository;
        }

        public IEnumerable<BloodUnitRequest> GetAll()
        {
            return _bloodUnitRequestRepository.GetAll();
        }

        public BloodUnitRequest GetById(int id)
        {
            return _bloodUnitRequestRepository.GetById(id);
        }

        public bool Create(BloodUnitRequest bloodUnitRequest)
        {
            _bloodUnitRequestRepository.Create(bloodUnitRequest);
            return true;
        }

        public void Update(BloodUnitRequest bloodUnitRequest)
        {
            _bloodUnitRequestRepository.Update(bloodUnitRequest);
        }


        public void UpdateUnclearRequest(BloodUnitRequest bloodUnitRequest)
        {
            if(bloodUnitRequest.Status == BloodUnitRequestStatus.REVIEWAGAIN || bloodUnitRequest.Status == BloodUnitRequestStatus.WAITING)
            {
                _bloodUnitRequestRepository.Update(bloodUnitRequest);
            }
        }

    }
}
