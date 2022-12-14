using HospitalLibrary.GraphicalEditor.Repository;
using HospitalLibrary.GraphicalEditor.Repository.Interfaces;
using HospitalLibrary.GraphicalEditor.Repository.Map.Interfaces;
using HospitalLibrary.GraphicalEditor.Service;
using HospitalLibrary.GraphicalEditor.Service.Interfaces;
using HospitalLibrary.Settings;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Repository;
using HospitalAPI.Converters;
using HospitalAPI.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Validation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using HospitalAPI.Mapper;
using HospitalLibrary.Core.Util;
using HospitalAPI.Connections;
using Microsoft.AspNetCore.Identity;
using HospitalAPI.Security;
using HospitalAPI.Security.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using AngleSharp.Io;
using HospitalAPI.Responses;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.Serialization;

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
            services.AddControllers();

            services.AddDbContext<HospitalDbContext>(options => 
            { 
                options.UseNpgsql(Configuration.GetConnectionString("HospitalDB")); 
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 
            });
            services.AddDbContext<AppIdentityDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("HospitalDB")));

            services.AddScoped(typeof(IFeedbackService), typeof(FeedbackService));
            services.AddScoped(typeof(IPatientService), typeof(PatientService));

            services.AddScoped(typeof(IFeedbackRepository), typeof(FeedbackRepository));
            services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));

            services.AddScoped(typeof(IAllergensRepository), typeof(AllergensRepository));
            services.AddScoped(typeof(IAllergenService), typeof(AllergenService));

            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));
            services.AddScoped(typeof(IAddressService), typeof(AddressService));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalAPI", Version = "v1" });
            });

            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();

            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IFloorRepository, FloorRepository>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IFormRepository, FormRepository>();

            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();

            services.AddScoped<IMapBuildingService, MapBuildingService>();
            services.AddScoped<IMapBuildingRepository, MapBuildingRepository>();

            services.AddScoped<IMapFloorService, MapFloorService>();
            services.AddScoped<IMapFloorRepository, MapFloorRepository>();

            services.AddScoped<IMapRoomService, MapRoomService>();
            services.AddScoped<IMapRoomRepository, MapRoomRepository>();

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            services.AddScoped<IExaminationService, ExaminationService>();
            services.AddScoped<IExaminationRepository, ExaminationRepository>();

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddScoped<IMapper<Examination, ExaminationDTO>, ExaminationMapper>();
            services.AddScoped<IMapper<TreatmentHistory, TreatmentHistoryDTO>, TreatmentHistoryMapper>();
            services.AddScoped<IMapper<Patient, PatientDTO>, PatientMapper>();  //mozda se ponovi pri merge

            services.AddScoped<IExaminationValidation, ExaminationValidation>();

            services.AddScoped<IBloodRepository, BloodRepository>();
            services.AddScoped<IBloodService, BloodService>();

            services.AddScoped<IMapper<Blood, BloodDTO>, BloodMapper>();

            services.AddScoped<ITreatmentHistoryService, TreatmentHistoryService>();
            services.AddScoped<ITreatmentHistoryRepository, TreatmentHistoryRepository>();

            services.AddScoped<IBedRepository, BedRepository>();

            services.AddScoped<ITherapyRepository, TherapyRepository>();
            services.AddScoped<ITherapyService, TherapyService>();

            services.AddScoped<IBloodUnitRepository, BloodUnitRepository>();

            services.AddScoped<IMedicalDrugsRepository, MedicalDrugsRepository>();
            services.AddScoped<IMedicalDrugsService, MedicalDrugsService>();

            services.AddScoped<AuthService>();
            services.AddScoped<ITherapyValidation, TherapyValidation>();

            services.AddScoped<IMapper<BloodUnitRequest, BloodUnitRequestDTO>, BloodUnitRequestMapper>();

            services.AddScoped<IBloodUnitRequestRepository, BloodUnitRequestRepository>();
            services.AddScoped<IBloodUnitRequestService, BloodUnitRequestService>();

            services.AddScoped<IBloodUnitRequestHTTPConnection, BloodUnitRequestHTTPConnection>();

            services.AddScoped<IExaminationValidation, ExaminationValidation>();

            services.AddScoped<IBloodUnitRepository, BloodUnitRepository>();
            services.AddScoped<IBloodUnitService, BloodUnitService>();

            services.AddScoped<IExaminationValidation, ExaminationValidation>();

            services.AddScoped<IMapper<Therapy, TherapyDTO>, TherapyMapper>();

            services.AddScoped<IConsiliumRepository, ConsiliumRepository>();
            services.AddScoped<IConsiliumService, ConsiliumService>();

            services.AddScoped<IResponseMapper<Consilium, ConsiliumResponse>, ConsiliumResponseMapper>();
            services.AddScoped<IResponseMapper<Doctor, ConsiliumDoctorResponse>, ConsiliumDoctorResponseMapper>();

            services.AddScoped<HospitalLibrary.Core.Util.DoctorScheduler>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "InternAllow",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .WithExposedHeaders("content-disposition");
                      });
                options.AddPolicy(name: "PublicAllow",
                policy =>
                {
                    policy.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                         .WithExposedHeaders("content-disposition");
                });
            });

            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalAPI v1"));
            }

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            app.UseRouting();

            app.UseCors("PublicAllow");
            app.UseCors("InternAllow");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
