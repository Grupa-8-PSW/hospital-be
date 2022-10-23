using HospitalAPI.Persistence;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private HospitalDbContext _context;

        public BloodBankRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(BloodBank bloodBank)
        {
            _context.bloodBanks.Add(bloodBank);
            _context.SaveChanges();
        }
    }
}
