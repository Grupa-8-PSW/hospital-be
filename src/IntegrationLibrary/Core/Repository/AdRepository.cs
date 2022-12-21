using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;

namespace IntegrationLibrary.Core.Repository
{
    public class AdRepository : IAdRepository
    {
        private readonly IntegrationDbContext _context;

        public AdRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public List<Ad> GetAll() => _context.Ads.ToList();

    }
}
