using HospitalAPI;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Enums;

namespace HospitalTests.HospitalAPITests.Setup
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<HospitalDbContext>();

                InitializeDatabase(db);
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<HospitalDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<HospitalDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=password;";
        }

        private static void InitializeDatabase(HospitalDbContext context)
        {
            context.Database.EnsureCreated();

            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Rooms\";");
            //context.Rooms.Add(new Room { Id = 1, FloorId = 1, Name = "11" });
            //context.Rooms.Add(new Room { Id = 2, FloorId = 1, Name = "12" });
            //context.Rooms.Add(new Room { Id = 3, FloorId = 2, Name = "21" });
            //context.Rooms.Add(new Room { Id = 4, FloorId = 3, Name = "31" });
            FillDbWithBlood(context);
            context.SaveChanges();
        }

        private static void FillDbWithBlood(HospitalDbContext context)
        {
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Bloods\";");
            context.Bloods.Add(new Blood(BloodType.A_POSITIVE, 1000, 1));
            context.Bloods.Add(new Blood(BloodType.AB_NEGATIVE, 1500, 2));
            context.Bloods.Add(new Blood(BloodType.ZERO_NEGATIVE, 500, 3));
        }
    }
}
