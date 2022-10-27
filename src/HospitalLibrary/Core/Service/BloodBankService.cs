using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

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
    }
}
