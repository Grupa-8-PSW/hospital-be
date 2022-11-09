using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public class BloodBankNewsRepository : IBloodBankNewsRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodBankNewsRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public void Create(BloodBankNews bloodBankNews)
        {
            _context.BloodBankNews.Add(bloodBankNews);
            _context.SaveChanges();
        }

        public void Delete(BloodBankNews bloodBankNews)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BloodBankNews> GetAll()
        {
            throw new NotImplementedException();
        }

        public BloodBankNews GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
