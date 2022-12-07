using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public class TenderOfferService : ITenderOfferService
    {
        private readonly ITenderOfferRepository _repository;

        public TenderOfferService(ITenderOfferRepository repo)
        {
            _repository = repo;
        }


        public TenderOffer Create(TenderOffer tenderOffer)
        {
            return _repository.Create(tenderOffer);
        }

        public IEnumerable<TenderOffer> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TenderOffer> getOffersForTender(int tenderID)
        {
            return _repository.GetAllByTennderID(tenderID);
        }
    }
}
