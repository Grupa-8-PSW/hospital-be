using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;


namespace HospitalLibrary.Core.Service
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(int id);
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
    }
}