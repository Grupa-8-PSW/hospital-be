using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

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
