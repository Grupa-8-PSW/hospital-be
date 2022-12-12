using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        private readonly IEmailService _emailService;

        public TenderOfferService(ITenderOfferRepository repo, IEmailService emailService)
        {
            _repository = repo;
            _emailService = emailService;
        }

        public TenderOffer AcceptTenderOffer(TenderOffer acceptedTenderOffer)
        {
            // promjeni status
            changeStatusForOffers(acceptedTenderOffer);

            // posalji mejlove
            _emailService.SendSuccessEmail(acceptedTenderOffer.BloodBankName);

            foreach(TenderOffer to in _repository.GetAll())
            {
                if (to.TenderOfferStatus == TenderOfferStatus.REJECT)
                {
                    _emailService.SendRejectEmail(to.BloodBankName);
                }
            }
            return acceptedTenderOffer;
        }

        public void changeStatusForOffers(TenderOffer acceptedTenderOffer)
        {
            _repository.UpdateTenderOffer(acceptedTenderOffer);
            foreach (TenderOffer to in _repository.GetAll())
            {
                if (to.TenderOfferStatus == TenderOfferStatus.WAITING)
                {
                    to.TenderOfferStatus = TenderOfferStatus.REJECT;
                    _repository.UpdateTenderOffer(to);
                }
            }
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
