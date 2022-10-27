using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IBloodBankService
    {
        IEnumerable<BloodBank> GetAll();
        void Create(BloodBank bloodBank);
        BloodBank GetById(int id);
        public void Delete(BloodBank bloodBank);
    }
}
