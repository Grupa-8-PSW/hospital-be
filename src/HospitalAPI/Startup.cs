﻿using HospitalAPI.Persistence;
using HospitalAPI.Persistence.Repository;
using HospitalAPI.Web.Converters;
using HospitalLibrary.Feedback;
using HospitalLibrary.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace HospitalAPI
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
            services.AddDbContext<HospitalDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("HospitalDB")));

            services.AddScoped(typeof(IFeedbackService), typeof(FeedbackService));
            services.AddScoped(typeof(IPatientService), typeof(PatientService));

            services.AddScoped(typeof(IFeedbackRepository), typeof(FeedbackRepository));
            services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalAPI", Version = "v1" });
            });
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
