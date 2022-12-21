using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationTeamTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace IntegrationTests.IntegrationAPITests.IntegrationTests
{
    public class AdTests : BaseIntegrationTests
    {
        public AdTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        [Fact]
        public void Retrieves_All_Ads()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            // Act
            var result = controller.Get();

            // Assert
            result.Result.ShouldBeOfType(typeof(OkObjectResult));
            var body = ((OkObjectResult)result.Result).Value;
            body.ShouldBeOfType(typeof(List<Ad>));
            ((List<Ad>)body).Count.ShouldBeGreaterThan(0);
        }

        private static AdController SetupController(IServiceScope scope)
        {
            return new AdController(scope.ServiceProvider.GetRequiredService<IAdService>());
        }

    }

}
