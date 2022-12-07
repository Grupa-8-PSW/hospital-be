using HospitalAPI;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalAPI.Security;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;

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
                var identityDb = scopedServices.GetRequiredService<AppIdentityDbContext>();

                InitializeDatabase(db);
                InitializeIdentityDatabase(identityDb);
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<HospitalDbContext>));
            services.Remove(descriptor);
            services.AddDbContext<HospitalDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));

            descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppIdentityDbContext>));
            services.Remove(descriptor);
            services.AddDbContext<AppIdentityDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));

            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=password;";
        }

        private static void InitializeDatabase(HospitalDbContext context)
        {

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodUnitRequests\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodUnits\";");

            context.Database.EnsureCreated();
            

            //context.BloodUnits.Add(new BloodUnit{ DatePrescribed = DateTime.Now, Amount = 50, BloodType = BloodType.A_POSITIVE });
            
            

            //context.Doctors.Add( new Doctor() { Id = 1, FirstName = "firstName", LastName = "lastName", RoomId = 1, StartWork = new DateTime(), EndWork = new DateTime() });
            //context.MedicalDrugs.Add( new MedicalDrugs() { Id = 1, Name = "Drugs1", Type = MedicalDrugType.PILL });

            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Rooms\";");
            // context.Rooms.Add(new Room { Id = 1, FloorId = 1, Name = "11" });
            //context.Rooms.Add(new Room { Id = 2, FloorId = 1, Name = "12" });
            //context.Rooms.Add(new Room { Id = 3, FloorId = 2, Name = "21" });
            //context.Rooms.Add(new Room { Id = 4, FloorId = 3, Name = "31" });
            //FillDbWithBlood(context);
            context.SaveChanges();
        }

        private static void FillDbWithBlood(HospitalDbContext context)
        {
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Bloods\";");
            context.Bloods.Add(new Blood(BloodType.A_POSITIVE, 1000, 1));
            context.Bloods.Add(new Blood(BloodType.AB_NEGATIVE, 1500, 2));
            context.Bloods.Add(new Blood(BloodType.ZERO_NEGATIVE, 500, 3));
        }

        private static void InitializeIdentityDatabase(AppIdentityDbContext context)
        {
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
  }
}
