using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IBloodBankService
    {
        IEnumerable<BloodBank> GetAll();
        void Create(BloodBank bloodBank);
    }
}
