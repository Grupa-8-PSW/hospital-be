using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.Repository.Interfaces;

public interface IMonthlySubscriptionRepository
{
    void Create(MonthlySubscription monthlySubscription);

    IEnumerable<MonthlySubscription> GetAll();

    MonthlySubscription GetLast();

    void Update(MonthlySubscription monthlySubscription);

    public MonthlySubscription GetById(int id);
}