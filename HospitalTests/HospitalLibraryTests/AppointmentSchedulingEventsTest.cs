using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model.Aggregates.AppointmentScheduling;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTests.HospitalLibraryTests
{
    public class AppointmentSchedulingEventsTest
    {
        [Fact]
        public void Get_average_number_of_steps()
        {
            var patientStubRepo = new Mock<IPatientRepository>();
            var service = new AppointmentSchedulingEventsService(CreateStubRepository(), patientStubRepo.Object);
            var averageNumberOfSteps = service.GetAverageNumberOfSteps();

            averageNumberOfSteps.ShouldBe(6);
        }
        [Fact]
        public void Get_number_of_view_each_step()
        {
            var patientStubRepo = new Mock<IPatientRepository>();
            var service = new AppointmentSchedulingEventsService(CreateStubRepository(), patientStubRepo.Object);
            var averageNumberOfEachStep = service.NumberOfViewsForStep();
            
            averageNumberOfEachStep.StepOne.ShouldBe(1);
            averageNumberOfEachStep.StepTwo.ShouldBe(1);
            averageNumberOfEachStep.StepThree.ShouldBe(1);
            averageNumberOfEachStep.StepFour.ShouldBe(1);

        }

        private IAppointmentEventWrapperRepository CreateStubRepository()
        {
            var events = new List<AppointmentEventWrapper>();
            var aggregateInts = new List<int>();
            aggregateInts.Add(1);
            var @event0 = new AppointmentEventWrapper(1, 1, null, EventType.SESSION_STARTED);
            var @event1 = new AppointmentEventWrapper(1, 1, null, EventType.DATE_TIME_SELECTED);
            var @event2 = new AppointmentEventWrapper(1, 1, null, EventType.DOCTOR_SPECIALIZATION_SELECTED);
            var @event3 = new AppointmentEventWrapper(1, 1, null, EventType.DOCTOR_SELECTED);
            var @event4 = new AppointmentEventWrapper(1, 1, null, EventType.APPOINTMENT_SELECTED);
            var @event5 = new AppointmentEventWrapper(1, 1, null, EventType.SESSION_END);
            events.Add(@event0);
            events.Add(@event1);
            events.Add(@event2);
            events.Add(@event3);
            events.Add(@event4);
            events.Add(@event5);

            var stubRepo = new Mock<IAppointmentEventWrapperRepository>();
            

            stubRepo.Setup(e => e.GetAll()).Returns(events);
            stubRepo.Setup(e => e.GetScheduledAggregates()).Returns(aggregateInts);

            return stubRepo.Object;

        }
    }
}
