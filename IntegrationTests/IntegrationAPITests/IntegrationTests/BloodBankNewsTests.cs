using IntegrationTeamTests.Setup;
using System;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using HospitalLibrary.Core.Service;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using IntegrationAPI.Connections;
using IntegrationTests.IntegrationAPITests.Mocks;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Core.Model;
using Shouldly;

namespace IntegrationTeamTests.Integration
{
    public class BloodBankNewsTests : BaseIntegrationTests
    {
        public BloodBankNewsTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static BloodBankRabbitMqConnection SetupRabbitMqConnection(IServiceScope scope)
        {
            return new BloodBankRabbitMqConnection(scope.ServiceProvider);
        }

        private static BloodBankNewsController SetupController(IServiceScope scope)
        {
            return new BloodBankNewsController(scope.ServiceProvider.GetRequiredService<IBloodBankNewsService>());
        }

        [Fact]
        public async Task Receives_BloodBank_News()
        {
            //ARANGE
            using var scope = Factory.Services.CreateScope();
            BloodBankRabbitMqConnection rabbitConnection = SetupRabbitMqConnection(scope);
            BloodBankNewsController controller = SetupController(scope);
            var allNews = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodBankNews>;
            int newsCountBefore = allNews.Count();

            //ACT
            await rabbitConnection.StartAsync(CancellationToken.None);
            RabbitMqPublisherMock.Send();
            await Task.Delay(1000);
            await rabbitConnection.StopAsync(CancellationToken.None);
            int newsCountAfter = (((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodBankNews>).Count();
            
            //ASSERT
            newsCountAfter.ShouldBe(newsCountBefore + 1);
        }
    }
}