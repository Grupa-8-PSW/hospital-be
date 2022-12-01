using IntegrationAPI.Connections;
using IntegrationAPI.Connections.Interface;
using IntegrationAPI.Middlewares;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using IntegrationAPI.ConnectionService;
using HospitalAPI.Connections;
using IntegrationAPI.Mapper;
using static IntegrationAPI.Mapper.IMapper;
using IntegrationAPI.Security;
using Microsoft.AspNetCore.Authentication;
using RestSharp;
using IntegrationLibrary.Persistence;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model;

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
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IntegrationAPI", Version = "v1" });
            });

            services.AddScoped<IBloodConsumptionConfigurationRepository, BloodConsumptionConfigurationRepository>();
            services.AddScoped<IBloodConsumptionConfigurationService, BloodConsumptionConfigurationService>();
            services.AddHostedService<BloodBankRabbitMqConnection>();

            services.AddScoped<ITenderOfferService, TenderOfferService>();
            services.AddScoped<ITenderOfferRepository, TenderOfferRepository>();

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
            services.AddScoped<IHospitalHTTPConnectionService, HospitalHTTPConnectionService>();
            services.AddScoped<IHospitalHTTPConnection, HospitalHTTPConnection>();
            services.AddScoped<IMapper<BloodBankNews, BloodBankNewsDTO>, BloodBankNewsMapper>();
            services.AddScoped<ITenderRepository, TenderRepository>();
            services.AddScoped<ITenderService, TenderService>();
            services.AddTransient<ExceptionMiddleware>();

            services.AddScoped<IHospitalAPIClient, HospitalAPIClient>();

            services.AddAuthentication("Default")
                .AddScheme<AuthenticationSchemeOptions, AuthHandler>("Default", null);
            services.AddAuthorization();

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


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

    }

}
