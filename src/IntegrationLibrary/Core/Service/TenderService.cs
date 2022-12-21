using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model.ValueObject;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;

namespace IntegrationLibrary.Core.Service
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly ITenderOfferRepository _tenderOfferRepository;

        public TenderService(ITenderRepository tenderRepository, ITenderOfferRepository tenderOfferRepository)
        {
            _tenderRepository = tenderRepository;
            _tenderOfferRepository = tenderOfferRepository;
        }

        public IEnumerable<Tender> GetAll()
        {
            return _tenderRepository.GetAll();
        }

        public void Create(Tender tender)
        {
            _tenderRepository.Create(tender);
        }

        public Tender GetById(int id)
        {
            return _tenderRepository.GetById(id);
        }

        public void Delete(Tender tender)
        {
            _tenderRepository.Delete(tender);
        }

        public IEnumerable<Tender> GetActiveTenders()
        {
            return _tenderRepository.GetActiveTenders();
        }

        public Tender UpdateStatus(int tenderID)
        {
            Tender tender = _tenderRepository.GetById(tenderID);
            tender.EndTenderLifeCycle();
            _tenderRepository.Update(tender);
            return tender;
        }

        public List<BloodOffer> GetBloodFromTenders(DateTime startTime, DateTime endTime)
        {
            List<BloodOffer> toRet = new List<BloodOffer>();
            foreach (Tender tender in GetAll())
            {
                if (tender.DateRange.Start > startTime && tender.DateRange.End < endTime)
                {
                    foreach (TenderOffer tenderOffer in _tenderOfferRepository.GetAllByTennderID(tender.Id))
                    {
                        if (tenderOffer.TenderOfferStatus.ToString().Equals("APPROVE"))
                        {
                            foreach (BloodOffer offer in tenderOffer.Offers)
                            {
                                toRet.Add(offer);
                            }
                        }
                    }
                }
            }
        
            return toRet;
        }
    }
}
