using IntegrationAPI.Domain.Validators;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Domain.Exceptions;
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
            BloodBankRequestValidator.Validate(bloodBank);
            _context.BloodBanks.Add(bloodBank);
            _context.SaveChanges();
        }

        public BloodBank GetById(int id)
        {
            if (id == 1)
            {
                return _context.BloodBanks.Find(id);
            }
            else
            {
                throw new BloodBankNotFound("Blood bank data not found");
            }
        }

        public void Delete(BloodBank bloodBank)
        {
            _context.BloodBanks.Remove(bloodBank);
            _context.SaveChanges();
        }
    }
}