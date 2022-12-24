using HospitalLibrary.Core.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Validation
{
    public interface IExaminationValidation
    {
        bool Validate(int doctorId, DateRange dateRange);

        List<string> SuggestFreeTime(int doctorId, DateTime startTime, int duration);

        bool DateCheck(DateTime start, DateTime? end);


        bool ValidateNotIncludingExaminationId(int doctorId, DateTime startTime, int duration, int examinationIdToIgnore);


        bool DateContainsDate(DateTime dateToContain, DateTime endTimeToContain, DateTime dateToBeContained, DateTime endTimeToBeContained);


        bool Intertwine(DateTime startTime1, int duration1, DateTime startTime2, int duration2);

    }
}