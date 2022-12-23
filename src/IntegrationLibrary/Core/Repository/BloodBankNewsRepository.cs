using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
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
            return _context.BloodBankNews.Include(b => b.BloodBank).Where(b => b.Archived == false).ToList();
        }

        public BloodBankNews GetById(int id)
        {
            return _context.BloodBankNews.Find(id);
        }

        public void Update(BloodBankNews bloodBankNews)
        {
            _context.Update(bloodBankNews);
            _context.SaveChanges();
        }
    }
}
