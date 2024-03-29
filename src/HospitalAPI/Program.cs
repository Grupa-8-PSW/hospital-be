using HospitalAPI.Security;
using HospitalLibrary.Settings.DataSeed;

namespace HospitalAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            //await AppIdentityDbContextSeed.SeedAsync(services);
            //RenovationEventSeed.SeedRenovationEvents(services);
            //AppointmentEventWrapperSeed.SeedAppointementEvents(services);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}