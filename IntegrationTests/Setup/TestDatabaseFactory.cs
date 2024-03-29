﻿using HospitalLibrary.Core.Enums;
using BloodUnit = HospitalLibrary.Core.Model.BloodUnit;
using HospitalAPI;
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
using Startup = IntegrationAPI.Startup;


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
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.BloodBanks.Add(new BloodBank { Name = "BloodBank1", Email = "email@email.com", Password = "password", ServerAddress = "serverAddress", APIKey = "1", MonthlySubscriptionRoutingKey="key" });
            String dt = "2022-11-23 19:00:00+01";
            DateTime date = DateTime.Parse(dt);
            //context.BloodConsumptionConfiguration.Add(
                //new BloodConsumptionConfiguration(10, date, TimeSpan.FromHours(3), TimeSpan.FromHours(50)));
            //context.BloodBankNews.Add(new BloodBankNews ( "text", "subject", 1, "img", false,  false, null, 1 ));

            context.SaveChanges();
        }

    }
}