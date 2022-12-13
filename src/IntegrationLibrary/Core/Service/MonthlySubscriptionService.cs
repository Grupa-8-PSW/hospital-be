using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;

namespace IntegrationLibrary.Core.Service;

public class MonthlySubscriptionService : IMonthlySubscriptionService
{
    private readonly IMonthlySubscriptionRepository _repository;

    public MonthlySubscriptionService(IMonthlySubscriptionRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<MonthlySubscription> GetAll()
    {
        return _repository.GetAll();
    }

    public void Create(MonthlySubscription subscription)
    {
        _repository.Create(subscription);
    }
    
}