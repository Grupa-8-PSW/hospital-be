using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Settings;
using Moq;
using Shouldly;

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

            Examination e1 = new Examination(1, 1, 1, 1, new DateTime(2022, 12, 1, 7, 0, 0, DateTimeKind.Utc), 20, 0);
            Examination e2 = new Examination(2, 1, 1, 2, new DateTime(2022, 12, 1, 8, 0, 0, DateTimeKind.Utc), 45, 0);
            Examination e3 = new Examination(3, 1, 2, 3, new DateTime(2022, 12, 15, 18, 30, 0, DateTimeKind.Utc), 7, 0);
            Examination e4 = new Examination(4, 2, 1, 3, new DateTime(2022, 12, 11, 23, 30, 0, DateTimeKind.Utc), 23, 0);
            Examination e5 = new Examination(5, 2, 1, 2, new DateTime(2022, 12, 20, 19, 30, 0, DateTimeKind.Utc), 24, 0);
            Examination e6 = new Examination(6, 1, 1, 1, new DateTime(2023, 10, 23, 14, 15, 0, DateTimeKind.Utc), 45, 0);

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