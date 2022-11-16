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

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodBanks\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodBankNews\"");
            context.BloodBanks.Add(new BloodBank { Id = 1, Name = "BloodBank1", Email = "email@email.com", Password = "password", ServerAddress = "serverAddress", APIKey = "12331232" });
            context.BloodBankNews.Add(new BloodBankNews { Id = 1, Subject = "subject", Text = "text", ImgSrc=String.Empty, Archived = false, Published = false, BloodBank = null, BloodBankId = 1});
            context.SaveChanges();
        }

    }
}