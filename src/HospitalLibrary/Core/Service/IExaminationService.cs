using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IExaminationService
    {
        IEnumerable<Examination> GetAll();
        Examination GetById(int id);
        bool Create(Examination examination);
        bool Update(Examination examination);
        void Delete(Examination examination);
        IEnumerable<Examination> GetByDate(DateTime startTime);
        IEnumerable<Examination> GetByYear(int startTime);
        IEnumerable<Examination> GetByMonth(int month);
        IEnumerable<Examination> GetByDoctorIdAndDate(int doctorId, DateTime startTime);
        IEnumerable<Examination> GetByRoomId(int roomId);
    }
}