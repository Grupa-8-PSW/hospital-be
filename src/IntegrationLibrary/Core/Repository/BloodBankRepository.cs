using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public BloodBank GetByApiKey(string apiKey)
        {
            return _context.BloodBanks.FirstOrDefault(b => b.APIKey == apiKey);
        }

        public void Delete(BloodBank bloodBank)
        {
            _context.BloodBanks.Remove(bloodBank);
            _context.SaveChanges();
        }

        public BloodBank getByName(string bloodBankName)
        {
            return _context.BloodBanks.FirstOrDefault(b => b.Name == bloodBankName);
        }
    }
}