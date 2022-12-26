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
using IntegrationLibrary.Core.Repository.Interfaces;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public List<Blood> GetAllBloodAmountsBetweenDates(DateTime from, DateTime to)
        {
            List<Blood> bloods = initializeList();

            IEnumerable<Tender> tenders = _tenderRepository.GetAllBloodAmountsBetweenDates(from, to);

            foreach(Tender tender in tenders ) {
                foreach (Blood blood in tender.Blood) {
                    foreach (var bl in bloods.Where(x => x.BloodType.Equals(blood.BloodType)))
                        bl.Quantity = bl.Quantity + blood.Quantity;
                }
            }
            
            return bloods;
        }

        public List<Dictionary<string, int>> GetBloodAmountsBetweenDates(DateTime from, DateTime to)
        {
            List<TenderOffer> toRet = new List<TenderOffer>();
            foreach (Tender tender in _tenderRepository.GetTendersBetweenDates(from, to))
            {
                if (_tenderOfferRepository.GetAcceptOffer(tender.Id) == null)
                    continue;
                
                toRet.Add(_tenderOfferRepository.GetAcceptOffer(tender.Id));
            }

            List<String> bankNames = FindBankNames(toRet);

            List<Dictionary<string, int>> quants = new List<Dictionary<string, int>>();

            foreach (String bankName in bankNames)
            {
                quants.Add(new Dictionary<string, int>(CalculateQuantitiesForBank(bankName, toRet)));
            }

            return quants;
        }

        private List<String> FindBankNames(List<TenderOffer> offers)
        {
            List<String> allNames = new List<string>();
            foreach (TenderOffer tenderOffer in offers)
            {
                allNames.Add(tenderOffer.BloodBankName);
            }

            return allNames.Distinct().ToList();

        }

        private Dictionary<string, int> CalculateQuantitiesForBank(String bankName, List<TenderOffer> allOffers)
        {
            List<String> allTypes = new List<string>();

            foreach (TenderOffer tenderOffer in allOffers)
            {
                if (tenderOffer.BloodBankName.Equals(bankName))
                {
                    allTypes.AddRange(tenderOffer.Offers.Select(tenderOfferOffer => tenderOfferOffer.BloodType));
                }
            }

            return FindQuantitiesForTypes(bankName, allOffers, allTypes.Distinct().ToList());
        }


        private Dictionary<string, int> FindQuantitiesForTypes(String bankName, List<TenderOffer> allOffers, List<String> allTypes)
        {
            Dictionary<string, int> typesAndQuantities = new Dictionary<string, int>();

            foreach (var type in allTypes)
            {
                typesAndQuantities.Add(type, 0);
            }

            foreach (string type in allTypes)
            {
                foreach (TenderOffer tenderOffer in allOffers)
                {
                    if (tenderOffer.BloodBankName.Equals(bankName))
                    {
                        foreach (var offer in tenderOffer.Offers)
                        {
                            if (offer.BloodType.Equals(type))
                            {
                                typesAndQuantities[type] += offer.BloodAmount;
                            }
                        }
                    }
                }
            }

            typesAndQuantities.Add(bankName, GetSumForBank(typesAndQuantities));

            return typesAndQuantities;
        }

        private int GetSumForBank(Dictionary<string, int> typesAndQuantities)
        {
            int sum = 0;
            foreach (var item in typesAndQuantities)
            {
                sum += item.Value;
            }

            return sum;
        }

        private List<Blood> initializeList()
        {
            List<Blood> bloods = new List<Blood>();
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.ZERO_POSITIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.A_POSITIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.B_POSITIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.AB_POSITIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.ZERO_NEGATIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.AB_NEGATIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.AB_POSITIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.A_NEGATIVE, 0));
            bloods.Add(new Blood(HospitalLibrary.Core.Enums.BloodType.B_NEGATIVE, 0));
            return bloods;
        }

    }
}
