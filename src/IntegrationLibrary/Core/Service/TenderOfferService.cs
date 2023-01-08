
using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.ValueObject;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Core.Service.Interfaces;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
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
        private readonly IBloodBankService _bankService;
        private readonly ITenderService _tenderService;

        public TenderOfferService(ITenderOfferRepository repo, IEmailService emailService, IBloodBankService bankService, ITenderService tenderService)
        {
            _repository = repo;
            _emailService = emailService;
            _bankService = bankService;
            _tenderService = tenderService;
        }

        public TenderOffer AcceptTenderOffer(TenderOffer acceptedTenderOffer, int tenderId)
        {
            BloodBank bb = _bankService.GetByName(acceptedTenderOffer.BloodBankName);

            Tender tender = _tenderService.GetById(tenderId);
            tender.Close(acceptedTenderOffer);
            _tenderService.Update(tender);
            _emailService.SendSuccessEmail(bb.Email, tenderId, bb.APIKey);
            foreach(TenderOffer to in tender.TenderOffers)
            {
                if (to.TenderOfferStatus == TenderOfferStatus.REJECT)
                {
                    BloodBank bb2 = _bankService.GetByName(acceptedTenderOffer.BloodBankName);
                    _emailService.SendRejectEmail(bb2.Email);
                }
            }
            return acceptedTenderOffer;

        }

        public TenderOffer Create(TenderOffer tenderOffer, int tenderId)
        {
            Tender tender = _tenderService.GetById(tenderId);
            tender.AddOffer(tenderOffer);
            _tenderService.Update(tender);
            return tenderOffer;
        }

        public IEnumerable<TenderOffer> GetAll()
        {
            return _repository.GetAll();
        }

        public TenderOffer GetAcceptedByTenderId(int tenderID)
        {
            return _tenderService.GetById(tenderID).GetAcceptedOffer();
        }

        public IEnumerable<TenderOffer> GetOffersForTender(int tenderID)
        {
            return _tenderService.GetById(tenderID).TenderOffers;
        }

    }
}
