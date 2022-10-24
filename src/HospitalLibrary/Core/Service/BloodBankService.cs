using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class BloodBankService : IBloodBankService
    {
        private readonly IBloodBankRepository _bloodBankRepository;


        public BloodBankService(IBloodBankRepository bloodBankRepository)
        {
            _bloodBankRepository = bloodBankRepository;
        }

        public void Create(BloodBank bloodBank)
        {
            _bloodBankRepository.Create(bloodBank);
        }

        public IEnumerable<BloodBank> GetAll()
        {
            return _bloodBankRepository.GetAll();
        }

    }
}
