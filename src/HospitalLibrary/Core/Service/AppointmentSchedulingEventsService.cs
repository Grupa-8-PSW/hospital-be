using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Aggregates;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling.Events;
using HospitalLibrary.Core.Model.ValueObjects;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentSchedulingEventsService : IAppointmentSchedulingEventsService
    {

        private readonly IAppointmentEventWrapperRepository _eventWrapperRepository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentSchedulingEventsService(IAppointmentEventWrapperRepository eventWrapperRepository, IPatientRepository patientRepository)
        {
            _eventWrapperRepository = eventWrapperRepository;
            _patientRepository = patientRepository;
        }

        public int SaveSessionStartedEvent(int patientId)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                PatientId = patientId,
                Data = new SessionStarted(DateTime.Now),
                EventType = Enums.EventType.SESSION_STARTED,
            };
            return _eventWrapperRepository.Create(e).AggregateId;
        }

        public void SaveDateTimeSelectedEvent(int aggregateId, int patientId, DateTime selectedDateTime)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                AggregateId = aggregateId,
                PatientId = patientId,
                Data = new DateTimeSelected(DateTime.Now, selectedDateTime),
                EventType = Enums.EventType.DATE_TIME_SELECTED
            };
            _eventWrapperRepository.Create(e);
        }

        public void SaveDoctorSpecializationSelectedEvent(int aggregateId, int patientId, DoctorSpecialization doctorSpecialization)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                AggregateId = aggregateId,
                PatientId = patientId,
                Data = new DoctorSpecializationSelected(DateTime.Now, doctorSpecialization),
                EventType = Enums.EventType.DOCTOR_SPECIALIZATION_SELECTED
            };
            _eventWrapperRepository.Create(e);
        }

        public void SaveDoctorSelectedEvent(int aggregateId, int patientId, int doctorId)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                AggregateId = aggregateId,
                PatientId = patientId,
                Data = new DoctorSelected(DateTime.Now, doctorId),
                EventType = Enums.EventType.DOCTOR_SELECTED
            };
            _eventWrapperRepository.Create(e);
        }

        public void SaveAppointmentSelectedEvent(int aggregateId, int patientId, DateRange dateRange)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                AggregateId = aggregateId,
                PatientId = patientId,
                Data = new AvailableAppointmentSelected(DateTime.Now, dateRange),
                EventType = Enums.EventType.APPOINTMENT_SELECTED
            };
            _eventWrapperRepository.Create(e);
        }

        public void SaveAppointmentScheduledEvent(int aggregateId, int patientId)
        {
            AppointmentEventWrapper e = new AppointmentEventWrapper()
            {
                AggregateId = aggregateId,
                PatientId = patientId,
                Data = new AppointmentScheduled(DateTime.Now),
                EventType = Enums.EventType.SESSION_END
            };
            _eventWrapperRepository.Create(e);
        }

        public int GetAverageNumberOfSteps()
        {
            var counts = new List<int>();
            int count = 0;
            foreach (var num in _eventWrapperRepository.GetScheduledAggregates())
            {
                foreach (var ev in _eventWrapperRepository.GetAll())
                {
                    if (num == ev.AggregateId && ev.EventType != EventType.SESSION_END && ev.EventType != EventType.SESSION_STARTED)
                    {
                        count += 1;
                    }
                }
                counts.Add(count);
                count = 0;
            }
            int sum = 0;
            foreach (var num in counts)
            {
                sum += num;
            }

            return sum / counts.Count;
        }
        public int GetAverageDurationInMins()
        {
            DateTime start = new();
            DateTime end = new();
            var mins = new List<int>();
            foreach (var num in _eventWrapperRepository.GetScheduledAggregates())
            {
                foreach (var ev in _eventWrapperRepository.GetAll())
                {
                    if (num == ev.AggregateId)
                    {
                        if(ev.EventType == EventType.SESSION_STARTED)
                        {
                            var obj = JsonObject.Parse(ev.Data.ToString());
                            start = Convert.ToDateTime(obj["Timestamp"].ToString());
                        }
                        if (ev.EventType == EventType.SESSION_END)
                        {
                            var obj = JsonObject.Parse(ev.Data.ToString());
                            end = Convert.ToDateTime(obj["Timestamp"].ToString());
                        }
                    }
                }
                var diff = end - start;
                mins.Add(diff.Seconds);
            }
            int sum = 0;
            foreach (var num in mins)
            {
                sum += num;
            }
            if(mins.Count > 0)
                return sum / mins.Count;
            return 0;
        }
        public StepViewCountStatistic NumberOfViewsForStep()
        {
            var stepCounter = new StepViewCountStatistic();
            foreach(var ev in _eventWrapperRepository.GetAll())
            {
                if(ev.EventType == EventType.SESSION_STARTED || ev.EventType == EventType.SESSION_END)
                {
                    continue;
                }
                if (ev.EventType == EventType.DATE_TIME_SELECTED)
                    stepCounter.StepOne++;
                if (ev.EventType == EventType.DOCTOR_SPECIALIZATION_SELECTED)
                    stepCounter.StepTwo++;
                if (ev.EventType == EventType.DOCTOR_SELECTED)
                    stepCounter.StepThree++;
                if (ev.EventType == EventType.APPOINTMENT_SELECTED)
                    stepCounter.StepFour++;
            }
            return stepCounter;
        }
        public SessionStepTimeSpent DurationViewingEachStep()
        {
            var sessionCounter = new SessionStepTimeSpent();
            var list = new List<SessionStepTimeSpent>();
            DateTime stepOne = new();
            DateTime stepTwo = new();
            DateTime stepThree = new();
            DateTime stepFour = new();
            DateTime start = new();

            foreach (var num in _eventWrapperRepository.GetScheduledAggregates())
            {
                var timeSpentStepOne = new TimeSpan();
                var timeSpentStepTwo = new TimeSpan();
                var timeSpentStepThree = new TimeSpan();
                var timeSpentStepFour = new TimeSpan();

                foreach (var ev in _eventWrapperRepository.GetAll())
                {
                    if (num == ev.AggregateId)
                    {
                        if (ev.EventType == EventType.SESSION_STARTED)
                        {
                            var obj = JsonObject.Parse(ev.Data.ToString());
                            start = Convert.ToDateTime(obj["Timestamp"].ToString());
                        }
                        else if (ev.EventType == EventType.DATE_TIME_SELECTED)
                        {
                            var obj = JsonObject.Parse(ev.Data.ToString());
                            stepOne = Convert.ToDateTime(obj["Timestamp"].ToString());
                            timeSpentStepOne += stepOne - start;
                        }
                        else if (ev.EventType == EventType.DOCTOR_SPECIALIZATION_SELECTED)
                        {
                            var obj = JsonObject.Parse(ev.Data.ToString());
                            stepTwo = Convert.ToDateTime(obj["Timestamp"].ToString());
                            timeSpentStepTwo += stepTwo - stepOne;
                        }
                        else if (ev.EventType == EventType.DOCTOR_SELECTED)
                        {
                            var obj = JsonObject.Parse(ev.Data.ToString());
                            stepThree = Convert.ToDateTime(obj["Timestamp"].ToString());
                            timeSpentStepThree += stepThree - stepTwo;
                        }
                        else if (ev.EventType == EventType.APPOINTMENT_SELECTED)
                        {
                            var obj = JsonObject.Parse(ev.Data.ToString());
                            stepFour = Convert.ToDateTime(obj["Timestamp"].ToString());
                            timeSpentStepFour += stepFour - stepThree;
                        } 
                    }
                }
                list.Add(new SessionStepTimeSpent(timeSpentStepOne.Seconds, timeSpentStepTwo.Seconds, timeSpentStepThree.Seconds, timeSpentStepFour.Seconds));
            }
            var sum1 = 0;
            var sum2 = 0;
            var sum3 = 0;
            var sum4 = 0;
            foreach(var ss in list)
            {
                sum1 += ss.StepOne;
                sum2 += ss.StepTwo;
                sum3 += ss.StepThree;
                sum4 += ss.StepFour;
            }
            sessionCounter.StepOne = sum1 / list.Count;
            sessionCounter.StepTwo = sum2 / list.Count;
            sessionCounter.StepThree = sum3 / list.Count;
            sessionCounter.StepFour = sum4 / list.Count;

            return sessionCounter;
        }

        public int GetPercentageOfSuccesfulSchedule()
        {
            var numOfSuccesful = Convert.ToDouble(_eventWrapperRepository.GetScheduledAggregates().Count);
            var total = Convert.ToDouble(_eventWrapperRepository.getNumOfAllAggregates());
            decimal temp2 = (decimal)(numOfSuccesful / total);
            var temp = Math.Round(temp2, 2);
            return (int)(temp * 100);
        }
        
        public AgeStatistic GetNumberOfStepsByAge()
        {
            var ageStat = new AgeStatistic();
            int count = 0;
            int patientId = 0;
            var countUnderEighteen = 0;
            var countOverEighteen = 0;
            var countOverSixtyFive = 0;

            foreach (var num in _eventWrapperRepository.GetScheduledAggregates())
            {
                foreach (var ev in _eventWrapperRepository.GetAll())
                {
                    if (num == ev.AggregateId && ev.EventType != EventType.SESSION_END && ev.EventType != EventType.SESSION_STARTED)
                    {
                        count += 1;
                        patientId = ev.PatientId;
                    }
                }
                if(_patientRepository.GetById(patientId).Pin.CalculateAge() <= 18)
                {
                    ageStat.ZeroToEighteen += count;
                    countUnderEighteen++;
                }
                else if (_patientRepository.GetById(patientId).Pin.CalculateAge() > 18 &&
                        _patientRepository.GetById(patientId).Pin.CalculateAge() <= 65)
                {
                    ageStat.NineteenToSixtyFour += count;
                    countOverEighteen++;
                }
                else if (_patientRepository.GetById(patientId).Pin.CalculateAge() > 65)
                {
                    ageStat.SixtyFivePlus += count;
                    countOverSixtyFive++;
                }
                
                count = 0;
            }

            if(countUnderEighteen != 0)
                ageStat.ZeroToEighteen /= countUnderEighteen;
            if(countOverEighteen != 0)
                ageStat.NineteenToSixtyFour /= countOverEighteen;
            if (countOverSixtyFive != 0)
                ageStat.SixtyFivePlus /= countOverSixtyFive;

            return ageStat;
        }

    }
}
