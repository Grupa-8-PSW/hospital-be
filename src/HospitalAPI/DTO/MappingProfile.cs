using AutoMapper;
using HospitalAPI.Security.Models;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feedback, FeedbackDTO>()
                .ForMember(f => f.PatientFullName, o => o.MapFrom(f => f.Patient.FullName));

            CreateMap<Feedback, PublicFeedbackDTO>()
                .ForMember(f => f.PatientFullName, o => o.MapFrom(f => f.Patient.FullName));

            CreateMap<CreateFeedbackDTO, Feedback>();

            CreateMap<Allergen, AllergenDTO>();
            CreateMap<AllergenDTO, Allergen>();

            CreateMap<Patient, PatientDTO>();

            CreateMap<Doctor, DoctorDTO>();

            CreateMap<RegisterUserDTO, Patient>()
                .ForMember(f => f.Allergens, o => o.MapFrom(f => f.Allergens));

            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();

            CreateMap<AvailableAppointments, AvailableAppointmentsDTO>();
            CreateMap<AvailableAppointmentsDTO, AvailableAppointments>();

            CreateMap<Statistic, StatisticDTO>();
        }

    }
}
