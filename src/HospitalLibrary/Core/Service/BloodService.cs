using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
