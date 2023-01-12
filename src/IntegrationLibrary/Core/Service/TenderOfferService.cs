using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.ValueObject;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        private readonly ITenderRepository _tenderRepository;

        public TenderOfferService(ITenderOfferRepository repo,ITenderRepository tenderRepository, IEmailService emailService, IBloodBankService bankService, ITenderService tenderService)
        {
            _repository = repo;
            _emailService = emailService;
            _bankService = bankService;
            _tenderService = tenderService;
            _tenderRepository = tenderRepository;
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

        public List<double> GetBloodPerMonth(int year, string bloodType)
        {
            var tenders = _tenderRepository.GetTendersByYear(year);
            List<TenderOffer> tenderOffers = new List<TenderOffer>();
            foreach (Tender tender in tenders)
            {
                tenderOffers.Add(_repository.GetAcceptedOffer(tender.Id));

            }
            List<double> bloodPerMonth = new List<double>();
            for (int i = 0; i < 12; i++)
            {
                bloodPerMonth.Add(0);
            }
            foreach(TenderOffer tOffer in tenderOffers)
            {
                foreach(BloodOffer bloodOffer in tOffer.Offers)
                {
                    if(bloodType == bloodOffer.BloodType)
                    {
                        foreach(Tender tender in tenders)
                        {
                            if(tOffer.TenderID == tender.Id)
                            {
                                bloodPerMonth[tender.DateRange.End.Month-1] += bloodOffer.BloodAmount;
                            }
                        }
                        
                    }
                }
            }
            
            return bloodPerMonth;
        }

        public List<decimal> GetMoneyPerMonth(int year)
        {
            var tenders = _tenderRepository.GetTendersByYear(year);
            List<TenderOffer> tenderOffers = new List<TenderOffer>();
            foreach (Tender tender in tenders)
            {
                tenderOffers.Add(_repository.GetAcceptedOffer(tender.Id));

            }
            List<decimal> moneyPerMonth = new List<decimal>();
            for (int i = 0; i < 12; i++)
            {
                moneyPerMonth.Add(0);
            }
            foreach (TenderOffer tOffer in tenderOffers)
            {
                foreach (BloodOffer bloodOffer in tOffer.Offers)
                {

                        foreach (Tender tender in tenders)
                        {
                            if (tOffer.TenderID == tender.Id)
                            {
                                moneyPerMonth[tender.DateRange.End.Month - 1] += (Decimal)bloodOffer.Price.Amount;
                            }
                        }

                }
            }

            return moneyPerMonth;
        }
    }
}
