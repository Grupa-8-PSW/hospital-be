using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;

namespace IntegrationLibrary.Core.Repository
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodBankRepository(IntegrationDbContext context)
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

        public BloodBank GetById(int id)
        {
            return _context.BloodBanks.Find(id);
        }

        public void Delete(BloodBank bloodBank)
        {
            _context.BloodBanks.Remove(bloodBank);
            _context.SaveChanges();
        }
    }
}