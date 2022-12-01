using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;

namespace IntegrationLibrary.Core.Repository
{
    public class TenderRepository : ITenderRepository
    {

        private readonly  IntegrationDbContext _context;

        public TenderRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tender> GetAll()
        {
            return _context.Tenders.ToList();
        }

        public void Create(Tender tender)
        {
            _context.Tenders.Add(tender);
            _context.SaveChanges();
        }

        public Tender GetById(int id)
        {
            return _context.Tenders.Find(id);
        }

        public void Delete(Tender tender)
        {
            _context.Tenders.Remove(tender);
            _context.SaveChanges();
        }

        public void Update(Tender tender)
        {
            _context.Tenders.Update(tender);
            _context.SaveChanges();
        }
    }
}
