using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Repository;

public class ConsiliumRepository : IConsiliumRepository
{
    private readonly HospitalDbContext _context;

    public ConsiliumRepository(HospitalDbContext context)
    {
        _context = context;
    }

    public async Task<List<Consilium>> GetAll()
    {
        return await _context.Consiliums.ToListAsync();
    }

    public async Task<Consilium?> GetById(int id)
    {
        return await _context.Consiliums.SingleOrDefaultAsync(c => c.Id == id);

    }

    public async Task<Consilium?> Create(Consilium consilium)
    {
        _context.Consiliums.Add(consilium);
        var created = await _context.SaveChangesAsync();

        return created > 0 ? consilium : null;
    }

    public async Task<bool> Update(Consilium consilium)
    {
        _context.Consiliums.Update(consilium);
        var updated = await _context.SaveChangesAsync();

        return updated > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var consilium = await _context.Consiliums.SingleOrDefaultAsync(c => c.Id == id);

        if (consilium == null)
            return false;

        _context.Remove(consilium);
        var deleted = await _context.SaveChangesAsync();

        return deleted > 0;
    }

    public async Task<List<Consilium>> GetAllIncludeDoctors()
    {
        var res = _context.Consiliums.Include(c => c.Doctors).ToQueryString();
        return null;
    }
}