using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class MedicalDrugsService : IMedicalDrugsService
    {
        private readonly IMedicalDrugsRepository _medicalDrugsRepository;

        public MedicalDrugsService(IMedicalDrugsRepository medicalDrugsRepository)
        {
            _medicalDrugsRepository = medicalDrugsRepository;
        }

        public IEnumerable<MedicalDrugs> GetAll()
        {
            return _medicalDrugsRepository.GetAll();
        }
    }
}
