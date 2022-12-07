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

        public TenderOffer Create(TenderOffer tenderOffer)
        {
            _context.TenderOffer.Add(tenderOffer);
            _context.SaveChanges();
            return tenderOffer;
        }

        public IEnumerable<TenderOffer> GetAll()
        {
            return _context.TenderOffer.ToList();
        }

        public IEnumerable<TenderOffer> GetAllByTennderID(int tenderId)
        {
            return _context.TenderOffer.Where(offer => offer.TenderID.Equals(tenderId));
        }


        //public List<Allergen> GetAllergensByDtoId(List<int> ids) => _dbContext.Allergens.Where(a => ids.Contains(a.Id)).ToList();


    }
}
