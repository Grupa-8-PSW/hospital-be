using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface ITherapyService
    {
        IEnumerable<Therapy> GetAll();
        Therapy GetById(int id);
        bool Create(Therapy therapy);
        bool Update(Therapy therapy);
    }
}
