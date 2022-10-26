﻿using AutoMapper;
using HospitalLibrary.Feedback;

namespace HospitalAPI.Web.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feedback, FeedbackDTO>()
                .ForMember(f => f.PatientFullName, o => o.MapFrom(f => f.Patient.FullName));

            CreateMap<Feedback, PublicFeedbackDTO>()
                .ForMember(f => f.PatientFullName, o => o.MapFrom(f => f.Patient.FullName));
        }

    }
}
