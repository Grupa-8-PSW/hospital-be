using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;

namespace IntegrationLibrary.Core.Service
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

        public void Delete(BloodBank bloodBank)
        {
            _bloodBankRepository.Delete(bloodBank);
        }

        public IEnumerable<BloodBank> GetAll()
        {
            return _bloodBankRepository.GetAll();
        }

        public BloodBank GetById(int id)
        {
            return _bloodBankRepository.GetById(id);
        }

        public BloodBank GetByName(string bloodBankName)
        {
            return _bloodBankRepository.getByName(bloodBankName);

        }
    }
}
