using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IBedRepository
    {
        public IEnumerable<Bed> GetAll();
        public Bed GetById(int id);
        public void Create(Bed bed);
        public void Update(Bed bed);
        public void Delete(Bed bed);
    }
}
