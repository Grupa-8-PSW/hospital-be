using HospitalLibrary.Core.DTO;
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
    public class ExaminationDoneService : IExaminationDoneService
    {
        private readonly IExaminationDoneRepository _examinationDoneRepository;
        //private readonly IExaminationValidation _validation;
        //private readonly IDoctorRepository _doctorRepository;

        public ExaminationDoneService(IExaminationDoneRepository examinationDoneRepository)
        {
            _examinationDoneRepository = examinationDoneRepository;

        }

        public IEnumerable<ExaminationDone> GetAll()
        {
            return _examinationDoneRepository.GetAll();
        }

        public ExaminationDone GetById(int id)
        {
            return _examinationDoneRepository.GetById(id);
        }

        public bool Create(ExaminationDone examinationDone)
        {
            /*if (!_validation.Validate(examination.DoctorId, examination.StartTime, examination.Duration))
            {
                return false;
            }*/
            _examinationDoneRepository.Create(examinationDone);
            return true;
        }

        public bool Update(ExaminationDone examinationDone)
        {
            /*if (!_validation.ValidateNotIncludingExaminationId(examination.DoctorId, examination.StartTime, examination.Duration, examination.Id))
            {
                return false;
            }
            Doctor doctor = _doctorRepository.GetById(examination.DoctorId);
            examination.Doctor = doctor;*/
            _examinationDoneRepository.Update(examinationDone);
            return true;
        }

        public void Delete(ExaminationDone examinationDone)
        {
            _examinationDoneRepository.Delete(examinationDone);
        }

        public IEnumerable<Symptom> GetAllSymptoms()
        {
            return _examinationDoneRepository.GetAllSymptoms();
        }

        public ExaminationDone? GetByExamination(int examinationId)
        {
            return _examinationDoneRepository.GetByExamination(examinationId);
        }
    
        public AverageExamsPerMonthDto CalculateAverageNumOfExamsPerMonth()
        {
            List<ExaminationDone> finishedExams = _examinationDoneRepository.GetAllFinished().ToList();
            List<TemporaryExamStatisticsDto> tempDtoList = new List<TemporaryExamStatisticsDto>();

            foreach (ExaminationDone exam in finishedExams)
            {
                DateTime currentDT = exam.Examination.DateRange.End;
                if (!tempDtoList.Exists(x => x.Month == currentDT.Month))
                {
                    TemporaryExamStatisticsDto dto = new TemporaryExamStatisticsDto(currentDT.Month, 1);
                    tempDtoList.Add(dto);
                }
                else
                {
                    TemporaryExamStatisticsDto dto = tempDtoList.Find(x => x.Month == currentDT.Month);
                    dto.ExamNum += 1;
                }
            }

            List<MonthExamStatisticsDto> monthDtoList = new List<MonthExamStatisticsDto>();
            tempDtoList.ForEach(e =>
            {
                MonthExamStatisticsDto monthExamStatisticsDto = new MonthExamStatisticsDto(e.Month, Math.Round((double)e.ExamNum/DateTime.DaysInMonth(2022, e.Month), 2));
            });

            return new AverageExamsPerMonthDto(monthDtoList);
        }
    }
}
