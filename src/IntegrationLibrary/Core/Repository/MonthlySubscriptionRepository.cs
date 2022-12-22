using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

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

    public MonthlySubscription GetById(int id)
    {
        return _context.MonthlySubscription.Find(id);
    }

    public MonthlySubscription GetLast()
    {
        return _context.MonthlySubscription.OrderBy(x => x.Id).Last();
    }

    public void Update(MonthlySubscription monthlySubscription)
    {
        _context.MonthlySubscription.Update(monthlySubscription);
        _context.SaveChanges();
    }

    public IEnumerable<MonthlySubscription> GetByBloodType(BloodType bloodType)
    {
        return _context.MonthlySubscription.Include(ms => ms.Bank).Where(ms => ms.RequestedBlood.Any(rb => rb.BloodType == bloodType)).ToList();
    }
}