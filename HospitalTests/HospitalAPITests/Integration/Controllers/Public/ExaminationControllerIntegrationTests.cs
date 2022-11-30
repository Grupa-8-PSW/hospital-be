using HospitalAPI;
using HospitalAPI.Controllers.PublicApp;
using HospitalLibrary.Core.Enums;
using HospitalTests.HospitalAPITests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace HospitalTests.HospitalAPITests.Integration.Controllers.Public
{
    public class ExaminationControllerIntegrationTests : BaseIntegrationTest
    {
        public ExaminationControllerIntegrationTests(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [MemberData(nameof(GetRecommendedExaminationTimeTestData))]
        public void GetRecommendedExaminationTime_ReturnsDataRangeList(
            DateTime from,
            DateTime to,
            int doctorId,
            AppointmentPriority priority)
        {
            // Arange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            // Act
            var result = controller.GetRecommendedExaminationTime(from, to, doctorId, priority);

            // Assert
            result.ShouldBeOfType(typeof(OkObjectResult));
        }

        private ExaminationController SetupController(IServiceScope scope)
        {
            return new ExaminationController();
        }

        private static readonly object[][] GetRecommendedExaminationTimeTestData =
        {
            new object[] { new DateTime(2022, 12, 1), new DateTime(2022, 12, 10), 1, AppointmentPriority.DOCTOR },
            new object[] { new DateTime(2022, 1, 1), new DateTime(2022, 1, 5), 1, AppointmentPriority.DATE }
        };

    }
}
