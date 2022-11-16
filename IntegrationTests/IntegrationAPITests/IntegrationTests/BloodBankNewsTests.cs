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
using IntegrationLibrary.Core.Model.DTO;
using System.Collections;

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

        private IEnumerable<BloodBankNews> GetAllBloodBankNews()
        {
            using var scope = Factory.Services.CreateScope();
            BloodBankNewsController controller = SetupController(scope);
            return ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodBankNews>;
        }


        private async Task<bool> ArrangeRabbitMq(BloodBankNewsDTO message) 
        {
            using var scope = Factory.Services.CreateScope();
            BloodBankRabbitMqConnection rabbitConnection = SetupRabbitMqConnection(scope);
            BloodBankNewsController controller = SetupController(scope);

            int newsCountBefore = GetAllBloodBankNews().Count();

            await rabbitConnection.StartAsync(CancellationToken.None);
            RabbitMqPublisherMock.Send(message);
            await Task.Delay(1000);
            await rabbitConnection.StopAsync(CancellationToken.None);

            int newsCountAfter = GetAllBloodBankNews().Count();
            return (newsCountAfter - newsCountBefore) > 0;
        }


        [Fact]
        public void Retrieves_All_News()
        {
            IEnumerable<BloodBankNews> allNews = GetAllBloodBankNews();

            allNews.ShouldNotBeNull();
        }


        [Theory]
        [ClassData(typeof(BloodBankNewsTestData))]
        public async Task Receives_BloodBank_News(BloodBankNewsDTO message, bool expected)
        {
            //ARRANGE AND ACT
            bool changed = await ArrangeRabbitMq(message);

            //ASSERT
            changed.ShouldBe(expected);
        }


        [Fact]
        public void Publishes_BloodBank_News()
        {
            using var scope = Factory.Services.CreateScope();
            BloodBankNewsController controller = SetupController(scope);
            BloodBankNews bloodBankNews = ((OkObjectResult)controller.GetById(1))?.Value as BloodBankNews;

            controller.PublishNews(bloodBankNews);
            bloodBankNews = ((OkObjectResult)controller.GetById(1))?.Value as BloodBankNews;

            bloodBankNews.Published.ShouldBeTrue();


        }
        [Fact]
        public void Archives_BloodBank_News()
        {
            using var scope = Factory.Services.CreateScope();
            BloodBankNewsController controller = SetupController(scope);
            BloodBankNews bloodBankNews = ((OkObjectResult)controller.GetById(1))?.Value as BloodBankNews;
            int newsCountBefore = GetAllBloodBankNews().Count();

            controller.ArchiveNews(bloodBankNews);
            int newsCountAfter = GetAllBloodBankNews().Count();

            newsCountAfter.ShouldBe(newsCountBefore - 1);

        }



    }

    public class BloodBankNewsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            BloodBankNewsDTO messageWithValidApiKey = new() { text = "text", bloodBankApiKey = "1", imgSrc = "", subject = "subject" };
            BloodBankNewsDTO messageWithInvalidApiKey = new() { text = "text", bloodBankApiKey = "invalid", imgSrc = "", subject = "subject" };
            yield return new object[] { messageWithValidApiKey, true };
            yield return new object[] { messageWithInvalidApiKey, false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}