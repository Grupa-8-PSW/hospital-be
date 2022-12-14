using IntegrationAPI.Controllers;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationTeamTests.Setup;
using iTextSharp.text;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IntegrationTests.IntegrationAPITests.IntegrationTests;

public class MonthlySubscriptionTests : BaseIntegrationTests
{
    public MonthlySubscriptionTests(TestDatabaseFactory<IntegrationAPI.Startup> databaseFactory) : base(databaseFactory)
    {

    }

    private static MonthlySubscriptionController setupController(IServiceScope scope)
    {
        return new MonthlySubscriptionController(
            scope.ServiceProvider.GetRequiredService<IMonthlySubscriptionService>(), scope.ServiceProvider.GetRequiredService<IBloodBankService>());
    }


    [Fact]
    public void TestCreateSubscription()
    {
        //Arange
        using var scope = Factory.Services.CreateScope();
        var controller = setupController(scope);
        List<IntegrationLibrary.Core.Model.Blood> bs = new List<IntegrationLibrary.Core.Model.Blood>();
        bs.Add(new IntegrationLibrary.Core.Model.Blood(HospitalLibrary.Core.Enums.BloodType.A_POSITIVE, 1));
        MonthlySubscription subscription = new MonthlySubscription(bs, DateTime.Now.ToUniversalTime(), null, 1, SubscriptionStatus.WAITING);

        //Act
        String retVal = controller.Create(subscription);

        //Assert
        Assert.Equal("success", retVal);
    }

}