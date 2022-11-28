using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace HospitalLibrary.Core.Validation
{
    public class ExaminationValidation : IExaminationValidation
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IDoctorRepository _doctorRepository;

        public ExaminationValidation(IExaminationRepository examinationRepository, IDoctorRepository doctorRepository)
        {
            _examinationRepository = examinationRepository;
            _doctorRepository = doctorRepository;
        }

        public List<string> SuggestFreeTime(int doctorId, DateTime startTime, int duration)
        {
            List<Examination> examinations = _examinationRepository.GetByDoctorIdAndDate(doctorId, startTime).ToList();
            examinations.Sort((ex1, ex2) => DateTime.Compare(ex1.StartTime, ex2.StartTime));

            Doctor doctor = _doctorRepository.GetById(doctorId);

            List<string> suggestedTime = new List<string>();
            DateTime begin = doctor.StartWork;
            DateTime? end = null;
            foreach (Examination examination in examinations)
            {
                end = examination.StartTime;
                if (DateCheck(begin, end))
                {
                    suggestedTime.Add(begin.ToString("HH:mm") + " - " + end?.ToString("HH:mm"));
                }
                begin = examination.StartTime.AddMinutes(duration);
            }
            if (DateCheck(begin, doctor.EndWork))
            {
                suggestedTime.Add(begin.ToString("HH:mm") + " - " + doctor.EndWork.ToString("HH:mm"));
            }
            return suggestedTime;
        }
        public bool DateCheck(DateTime start, DateTime? end)
        {
            var diffOfDates = start - end;
            return diffOfDates?.Minutes > 15;
        }
        public bool Validate(int doctorId, DateTime startTime, int duration)
        {
            Doctor doctor = _doctorRepository.GetById(doctorId);
            if (!DateContainsDate(doctor.StartWork, doctor.EndWork, startTime, startTime.AddMinutes(duration)))
            {
                return false;
            }


            IEnumerable<Examination> examinations = _examinationRepository.GetByDoctorIdAndDate(doctorId, startTime);
            foreach (Examination examination in examinations)
            {
                if (Intertwine(startTime, duration, examination.StartTime, examination.Duration))
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValidateNotIncludingExaminationId(int doctorId, DateTime startTime, int duration, int examinationIdToIgnore)
        {
            Doctor doctor = _doctorRepository.GetById(doctorId);
            if (!DateContainsDate(doctor.StartWork, doctor.EndWork, startTime, startTime.AddMinutes(duration)))
            {
                return false;
            }

            IEnumerable<Examination> examinations = _examinationRepository.GetByDoctorIdAndDate(doctorId, startTime);
            examinations = examinations.Where(ex => ex.Id != examinationIdToIgnore).ToList();
            foreach (Examination examination in examinations)
            {
                if (Intertwine(startTime, duration, examination.StartTime, examination.Duration))
                {
                    return false;
                }
            }

            return true;
        }

        public bool DateContainsDate(DateTime dateToContain, DateTime endTimeToContain, DateTime dateToBeContained, DateTime endTimeToBeContained)
        {
            if (dateToContain.TimeOfDay < dateToBeContained.TimeOfDay && endTimeToContain.TimeOfDay > endTimeToBeContained.TimeOfDay)
            {
                return true;
            }

            return false;
        }

        public bool Intertwine(DateTime startTime1, int duration1, DateTime startTime2, int duration2)
        {
            DateTime endTime1 = startTime1.AddMinutes(duration1);
            DateTime endTime2 = startTime2.AddMinutes(duration2);
            if (endTime2 < startTime1 || startTime2 > endTime1)
            {
                return false;
            }

            return true;
        }
    }
}