using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;

namespace IntegrationLibrary.Core.Repository;

public class MonthlySubscriptionRepository : IMonthlySubscriptionRepository
{
    private readonly IntegrationDbContext _context;

    public MonthlySubscriptionRepository(IntegrationDbContext context)
    {
        _context = context;
    }

    public void Create(MonthlySubscription monthlySubscription)
    {
        _context.MonthlySubscription.Add(monthlySubscription);
        _context.SaveChanges();
    }

    public IEnumerable<MonthlySubscription> GetAll()
    {
        return _context.MonthlySubscription.ToList();
    }
}