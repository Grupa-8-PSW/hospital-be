using IntegrationAPI.Connections;
using IntegrationAPI.Connections.Interface;
using IntegrationAPI.Middlewares;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service;
using IntegrationLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using IntegrationLibrary.Core.Service.Interfaces;

namespace IntegrationAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IntegrationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("IntegrationDB")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IntegrationAPI", Version = "v1" });
            });

            services.AddScoped<IBloodConsumptionConfigurationRepository, BloodConsumptionConfigurationRepository>();
            services.AddScoped<IBloodConsumptionConfigurationService, BloodConsumptionConfigurationService>();
            services.AddHostedService<BloodBankRabbitMqConnection>();

            services.AddScoped<IBloodBankConnectionService, BloodBankConnectionService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IBloodBankService, BloodBankService>();
            services.AddScoped<IBloodBankRepository, BloodBankRepository>();
            services.AddScoped<IBloodBankHTTPConnection, BloodBankHTTPConnection>();
            services.AddScoped<IBloodBankConnectionService, BloodBankConnectionService>();
            services.AddScoped<ICredentialGenerator, CredentialGenerator>();
            services.AddScoped<IBloodBankHTTPConnection, BloodBankHTTPConnection>();
            services.AddScoped<IBloodBankNewsRepository, BloodBankNewsRepository>();
            services.AddScoped<IBloodBankNewsService, BloodBankNewsService>();
            services.AddTransient<ExceptionMiddleware>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalAPI v1"));
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }

    }

}
