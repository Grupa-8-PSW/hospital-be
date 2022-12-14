using AutoMapper;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Service;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationTeamTests.Setup;
using iTextSharp.text;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static IntegrationAPI.Mapper.IMapper;

namespace IntegrationTests.IntegrationAPITests.IntegrationTests;

public class MonthlySubscriptionTests : BaseIntegrationTests
{
    public MonthlySubscriptionTests(TestDatabaseFactory<IntegrationAPI.Startup> databaseFactory) : base(databaseFactory)
    {

    }

    private static MonthlySubscriptionController setupController(IServiceScope scope)
    {
        return new MonthlySubscriptionController(
            scope.ServiceProvider.GetRequiredService<IMonthlySubscriptionService>(), scope.ServiceProvider.GetRequiredService<IBloodBankService>(),
            scope.ServiceProvider.GetRequiredService<IBloodBankConnectionService>(),
            scope.ServiceProvider.GetRequiredService<IMapper<MonthlySubscription, MonthlySubscriptionDTO>>());
    }


    [Fact]
    public void TestCreateSubscription()
    {
        //Arange
        using var scope = Factory.Services.CreateScope();
        var controller = setupController(scope);
        List<IntegrationLibrary.Core.Model.ValueObject.Blood> bs = new List<IntegrationLibrary.Core.Model.ValueObject.Blood>();
        bs.Add(new IntegrationLibrary.Core.Model.ValueObject.Blood(HospitalLibrary.Core.Enums.BloodType.A_POSITIVE, 1));
        MonthlySubscriptionDTO subscription = new MonthlySubscriptionDTO();
        subscription.Status = SubscriptionStatus.WAITING;
        subscription.DeliveryDate = DateTime.Now.ToUniversalTime();
        subscription.Bank = null;
        subscription.BankId = 1;
        subscription.RequestedBlood = bs;

        //Act
        String retVal = controller.Create(subscription);

        //Assert
        Assert.Equal("success", retVal);
    }

}