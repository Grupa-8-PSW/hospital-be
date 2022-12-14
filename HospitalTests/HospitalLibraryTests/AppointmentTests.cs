using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Settings;
using Moq;
using Shouldly;
using HospitalLibrary.Core.Model.ValueObjects;

namespace HospitalTests
{
    public class AppointmentTests
    {
        [Fact]
        public void Checks_if_cancellable()
        {
            ExaminationService service = new ExaminationService(CreateStubRepository());

            bool isCancellable = service.CheckIfCancellable(1);

            isCancellable.ShouldBe(false);
        }

        private IExaminationRepository CreateStubRepository()
        {
            List<Examination> examinations = new List<Examination>();

            Examination e1 = new Examination(1, 1, 1, 1, new DateRange(new DateTime(2022, 11, 1, 7, 0, 0), new DateTime(2022, 12, 1, 7, 30, 0)));
            Examination e2 = new Examination(2, 1, 2, 1, new DateRange(new DateTime(2022, 11, 1, 8, 0, 0), new DateTime(2022, 12, 1, 8, 30, 0)));
            Examination e3 = new Examination(3, 1, 3, 1, new DateRange(new DateTime(2022, 11, 1, 8, 30, 0), new DateTime(2022, 12, 1, 9, 0, 0)));
            Examination e4 = new Examination(4, 2, 1, 2, new DateRange(new DateTime(2022, 11, 16, 6, 0, 0), new DateTime(2022, 12, 16, 6, 30, 0)));
            Examination e5 = new Examination(5, 2, 1, 2, new DateRange(new DateTime(2022, 11, 25, 9, 0, 0), new DateTime(2022, 12, 25, 9, 30, 0)));
            Examination e6 = new Examination(6, 1, 1, 1, new DateRange(new DateTime(2022, 11, 27, 10, 0, 0), new DateTime(2022, 12, 27, 10, 30, 0)));

            examinations.Add(e1);
            examinations.Add(e2);
            examinations.Add(e3);
            examinations.Add(e4);
            examinations.Add(e5);
            examinations.Add(e6);

            var stubRepository = new Mock<IExaminationRepository>();

            stubRepository.Setup(m => m.GetById(1)).Returns(examinations.SingleOrDefault(p => p.Id == 1));

            return stubRepository.Object;
        }
    }
}