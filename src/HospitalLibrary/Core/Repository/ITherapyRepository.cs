using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface ITherapyRepository
    {
        IEnumerable<Therapy> GetAll();
        Therapy GetById(int id);
        void Create(Therapy examination);
        void Update(Therapy examination);
        void Delete(Therapy examination);


    }
}
