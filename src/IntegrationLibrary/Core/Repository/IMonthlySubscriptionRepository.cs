using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.Repository;

public interface IMonthlySubscriptionRepository
{
    void Create(MonthlySubscription monthlySubscription);

    IEnumerable<MonthlySubscription> GetAll();

    MonthlySubscription GetLast();

    void Update(MonthlySubscription monthlySubscription);

    public MonthlySubscription GetById(int id);
    public IEnumerable<MonthlySubscription> GetByBloodType(BloodType bloodType);
}