using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalLibrary.Core.Model;
using System.Threading.Tasks;


namespace HospitalLibrary.Core.Repository
{
    public interface IExaminationRepository
    {
        IEnumerable<Examination> GetAll();
        Examination GetById(int id);
        void Create(Examination examination);
        void Update(Examination examination);
        void Delete(Examination examination);


        IEnumerable<Examination> GetByDate(DateTime startTime);
        IEnumerable<Examination> GetByYear(int startTime);
        IEnumerable<Examination> GetByMonth(int month);
        IEnumerable<Examination> GetByDoctorIdAndDate(int doctorId, DateTime startTime);
        IEnumerable<Examination> GetByRoomId(int roomId);
    }
}