using IntegrationAPI;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTeamTests.Setup
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<IntegrationDbContext>();

                InitializeDatabase(db);
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<IntegrationDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<IntegrationDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));



            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Server=localhost;Port=5432;Database=IntegrationTestsDB;User Id=postgres;Password=password";
        }

        private static void InitializeDatabase(IntegrationDbContext context)
        {
            context.Database.EnsureCreated();

            //context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodBankNews\"");
            
           // context.BloodBankNews.Add(new BloodBankNews { id = 1, subject = "subject", text = "text", byteArray = Array.Empty<byte>(), archived = false, published = false });


            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodConsumptionConfiguration\";");


            DateTime sd = new DateTime(2011, 1, 5, 5, 2, 3);
            DateTime ss = DateTime.SpecifyKind(sd, DateTimeKind.Utc);

            context.BloodConsumptionConfiguration.Add(new BloodConsumptionConfiguration { ConsumptionPeriodHours = new TimeSpan(1, 2, 1), StartDateTime= ss, FrequencyPeriodInHours=new TimeSpan(1, 2, 3)});


            context.SaveChanges();
        }

    }
}