using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text.Json;

namespace HospitalLibrary.Core.Service
{
    public class BloodService : IBloodService
    {
        private readonly IBloodRepository _bloodRepo;

        public BloodService(IBloodRepository bloodRepo)
        {
            this._bloodRepo = bloodRepo;
        }

        public List<Blood> GetAll()
        {
            return _bloodRepo.GetAll();
        }

        public Blood GetById(int id)
        {
            return _bloodRepo.GetById(id);
        }


        public Blood Create(Blood entity)
        {
            return _bloodRepo.Create(entity);
        }

        public void Delete(int id)
        {
            _bloodRepo.Delete(id);
        }

        public void Update(int id, Blood entity)
        {
            _bloodRepo.Update(entity);
        }

        public void RestockBlood(int id, Blood blood)   
        {
            Blood oldBlood = _bloodRepo.GetByBloodType(blood.Type);
            blood.Quantity = oldBlood.Quantity + blood.Quantity;
            _bloodRepo.RestockBlood(blood);
        }

        public List<double> GetBloodPerMonth(int year, string bloodType)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://localhost:7131/api/TenderOffer/{year}/{bloodType}");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<List<double>>(json);
            }
        }

        public List<double> GetMoneyPerMonth(int year)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://localhost:7131/api/TenderOffer/{year}");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<List<double>>(json);
            }
        }
    }
}
