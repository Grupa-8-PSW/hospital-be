using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using MimeKit;
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

        public void UpdateTenderOffer(TenderOffer newTenderOffer)
        {
            TenderOffer bloodUnitOld = _context.TenderOffer.Find(newTenderOffer.Id);
            _context.Entry(bloodUnitOld).CurrentValues.SetValues(newTenderOffer);

            _context.SaveChanges();
            

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

        public TenderOffer GetAcceptedOffer(int tenderID)
        {
            return  _context.TenderOffer.Where(p => p.TenderID.Equals(tenderID)).Where(p => p.TenderOfferStatus.Equals(TenderOfferStatus.APPROVE)).First();
        }


        public TenderOffer GetAcceptOffer(int tenderId)
        {
            var toRet = _context.TenderOffer
                .FromSqlRaw("select * from \"TenderOffer\" where \"TenderID\" = {0} and \"TenderOfferStatus\" = 1",
                    tenderId).FirstOrDefault();

            if (toRet == null)
            {
                return null;
            }

            return toRet;
        }
    }
}
