
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

        public TenderOffer AcceptTenderOffer(TenderOffer acceptedTenderOffer)
        {
            BloodBank bb = _bankService.GetByName(acceptedTenderOffer.BloodBankName);

            changeStatusForOffers(acceptedTenderOffer);
            ChangeTenderStatus(acceptedTenderOffer.TenderID);

            _emailService.SendSuccessEmail(bb.Email, acceptedTenderOffer.TenderID, bb.APIKey);

            foreach(TenderOffer to in _repository.GetAll())
            {
                if (to.TenderOfferStatus == TenderOfferStatus.REJECT && to.TenderID.Equals(acceptedTenderOffer.TenderID))
                {
                    BloodBank bb2 = _bankService.GetByName(acceptedTenderOffer.BloodBankName);
                    _emailService.SendRejectEmail(bb2.Email);
                }
            }
            return acceptedTenderOffer;
        }

        public void ChangeTenderStatus(int tenderID)
        {
            _tenderService.UpdateStatus(tenderID);
        }

        public void changeStatusForOffers(TenderOffer acceptedTenderOffer)
        {
            _repository.UpdateTenderOffer(acceptedTenderOffer);
            foreach (TenderOffer to in _repository.GetAll())
            {
                if (to.TenderOfferStatus == TenderOfferStatus.WAITING && to.TenderID.Equals(acceptedTenderOffer.TenderID))
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

        public TenderOffer GetById(int tenderID)
        {
            return _repository.GetAcceptedOffer(tenderID);
        }

        public IEnumerable<TenderOffer> getOffersForTender(int tenderID)
        {
            return _repository.GetAllByTennderID(tenderID);
        }

        public IEnumerable<TenderOffer> GetAllBloodAmountsBetweenDates(DateTime from, DateTime to)
        {

            from = new DateTime(2022, 11, 11);
            to = new DateTime(2023, 11, 11);

            IEnumerable<TenderOffer> tenders = _repository.Getbetw(from, to);


            return tenders;
        }




    }
}
