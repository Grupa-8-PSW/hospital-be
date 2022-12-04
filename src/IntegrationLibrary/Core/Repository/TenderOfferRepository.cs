using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Repository
{
    public class TenderOfferRepository : ITenderOfferRepository
    {
        private readonly IntegrationDbContext _context;


        public TenderOfferRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public tenderOfferDTO Create(tenderOfferDTO tenderOffer)
        {
            _context.TenderOffer.Add(tenderOffer);
            _context.SaveChanges();
            return tenderOffer;
        }

        public IEnumerable<tenderOfferDTO> GetAll()
        {
            return _context.TenderOffer.ToList();
        }


        //public List<Allergen> GetAllergensByDtoId(List<int> ids) => _dbContext.Allergens.Where(a => ids.Contains(a.Id)).ToList();

        public IEnumerable<tenderOfferDTO> GetAllByTennderID()
        {
            throw new NotImplementedException();
        }
    }
}
