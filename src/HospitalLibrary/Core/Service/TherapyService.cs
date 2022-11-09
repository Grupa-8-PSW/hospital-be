using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class TherapyService : ITherapyService
    {
        private readonly ITherapyRepository _therapyRepository;

        public TherapyService(ITherapyRepository therapyRepository)
        {
            _therapyRepository = therapyRepository;
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _therapyRepository.GetAll();
        }

        public Therapy GetById(int id)
        {
            return _therapyRepository.GetById(id);
        }

        public bool Create(Therapy therapy)
        {
            _therapyRepository.Create(therapy);
            return true;
        }

        public bool Update(Therapy therapy)
        {
            _therapyRepository.Update(therapy);
            return true;
        }

    }
}
