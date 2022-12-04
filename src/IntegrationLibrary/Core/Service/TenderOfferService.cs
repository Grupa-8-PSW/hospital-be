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


        public tenderOfferDTO Create(tenderOfferDTO tenderOffer)
        {
            return _repository.Create(tenderOffer);
        }

        public IEnumerable<tenderOfferDTO> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
