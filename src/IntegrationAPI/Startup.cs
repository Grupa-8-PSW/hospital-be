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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:ValidIssuer"],
                    //ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddAuthentication();
            services.AddAuthorization();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
        }

    }

}
