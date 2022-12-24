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
            ExaminationService service = new ExaminationService(CreateStubRepository(), null, null);

            bool isCancellable = service.CheckIfCancellable(1);

            isCancellable.ShouldBe(false);
        }

        private IExaminationRepository CreateStubRepository()
        {
            List<Examination> examinations = new List<Examination>();

            Examination e1 = new Examination(1, 1, 1, 1, new DateRange(new DateTime(2022, 11, 1, 7, 0, 0), new DateTime(2022, 11, 1, 7, 30, 0)));
            Examination e2 = new Examination(2, 1, 2, 1, new DateRange(new DateTime(2099, 11, 1, 8, 0, 0), new DateTime(2099, 12, 1, 8, 30, 0)));

            examinations.Add(e1);
            examinations.Add(e2);

            var stubRepository = new Mock<IExaminationRepository>();

            stubRepository.Setup(m => m.GetById(1)).Returns(examinations.SingleOrDefault(p => p.Id == 1));

            return stubRepository.Object;
        }
    }
}