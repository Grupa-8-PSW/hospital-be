using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.Core.Service
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
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
            tender.Status = TenderStatus.Inactive;
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
