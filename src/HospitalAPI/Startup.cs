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
using HospitalAPI.Mapper;

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
            services.AddDbContext<HospitalDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("HospitalDB")));
            services.AddControllers();

            services.AddScoped(typeof(IFeedbackService), typeof(FeedbackService));
            services.AddScoped(typeof(IPatientService), typeof(PatientService));

            services.AddScoped(typeof(IFeedbackRepository), typeof(FeedbackRepository));
            services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
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

            services.AddScoped<IMapper<Examination, ExaminationDTO>, ExaminationMapper>();
            services.AddScoped<IMapper<TreatmentHistory, TreatmentHistoryDTO>, TreatmentHistoryMapper>();
            services.AddScoped<IMapper<Patient, PatientDTO>, PatientMapper>();  //mozda se ponovi pri merge

            services.AddScoped<IValidation, ExaminationValidation>();

            services.AddScoped<ITreatmentHistoryService, TreatmentHistoryService>();
            services.AddScoped<ITreatmentHistoryRepository, TreatmentHistoryRepository>();

            services.AddScoped<IBedRepository, BedRepository>();

            services.AddScoped<ITherapyRepository, TherapyRepository>();
            services.AddScoped<ITherapyService, TherapyService>();
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
