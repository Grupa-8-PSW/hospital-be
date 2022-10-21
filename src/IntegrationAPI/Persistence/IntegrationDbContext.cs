using Microsoft.EntityFrameworkCore;

namespace IntegrationAPI.Persistence
{
    public class IntegrationDbContext: DbContext
    {

        public IntegrationDbContext(DbContextOptions options): base(options) { }

    }
}
