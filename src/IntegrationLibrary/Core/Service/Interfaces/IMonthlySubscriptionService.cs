using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.Service.Interfaces;

public interface IMonthlySubscriptionService
{
    IEnumerable<MonthlySubscription> GetAll();

    void Create(MonthlySubscription subscription);
}