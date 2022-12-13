using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.Repository;

public interface IMonthlySubscriptionRepository
{
    void Create(MonthlySubscription monthlySubscription);

    IEnumerable<MonthlySubscription> GetAll();
}