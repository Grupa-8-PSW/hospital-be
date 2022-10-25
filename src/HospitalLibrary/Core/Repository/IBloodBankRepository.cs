using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IBloodBankRepository
    {

        IEnumerable<BloodBank> GetAll();
        void Create(BloodBank bloodBank);

    }
}
