using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(int id);
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
    }

}