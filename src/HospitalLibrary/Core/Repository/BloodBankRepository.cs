using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private readonly HospitalDbContext _context;

        public BloodBankRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodBank> GetAll()
        {
            return _context.BloodBanks.ToList();    
        }

        public void Create(BloodBank bloodBank)
        {
            _context.BloodBanks.Add(bloodBank);
            _context.SaveChanges();
        }

    }
}
