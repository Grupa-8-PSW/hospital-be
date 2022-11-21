using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IBloodUnitRepository
    {
        IEnumerable<BloodUnit> GetAll();
        BloodUnit GetById(int id);
        void Create(BloodUnit bloodUnit);
        void Update(BloodUnit bloodUnit);
        void Delete(BloodUnit bloodUnit);
    }
}
