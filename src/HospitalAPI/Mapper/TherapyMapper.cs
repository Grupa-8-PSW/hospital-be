using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace HospitalAPI.Mapper
{
    public class TherapyMapper : IMapper<Therapy, TherapyDTO>
    {
        public TherapyDTO toDTO(Therapy model)
        {
            var therapyDTO = new TherapyDTO();
            therapyDTO.Id = model.Id;
            therapyDTO.WhenPrescribed = model.WhenPrescribed.ToString("dd/MM/yyyy");
            therapyDTO.Amount = model.Amount;
            therapyDTO.Reason = model.Reason;
            therapyDTO.TherapyType = model.TherapyType.ToString();
            therapyDTO.TherapySubject = model.TherapySubject;
            therapyDTO.DoctorId = model.DoctorId;
            therapyDTO.TreatmentHistoryId = model.TreatmentHistoryId;
            return therapyDTO;
        }

        public Collection<TherapyDTO> toDTO(Collection<Therapy> models)
        {
            return new Collection<TherapyDTO>(models
                .Select<Therapy, TherapyDTO>((therapy) => this.toDTO(therapy))
                .ToList<TherapyDTO>());
        }

        public Therapy toModel(TherapyDTO dto)
        {
            Therapy therapy = new Therapy();
            if (dto.Id.HasValue)
            {
                therapy.Id = dto.Id.Value;
            }
            therapy.WhenPrescribed = DateTime.ParseExact(dto.WhenPrescribed, "dd/MM/yyyy", null).ToUniversalTime();
            therapy.Amount = dto.Amount;
            therapy.Reason = dto.Reason;
            TherapyType therapyType;
            if (!Enum.TryParse<TherapyType>(dto.TherapySubject, out therapyType))
            {
                return null;
            }

            therapy.TherapyType = therapyType;
            therapy.TherapySubject = dto.TherapySubject;

            therapy.DoctorId = dto.DoctorId;
            therapy.TreatmentHistoryId = dto.TreatmentHistoryId;

            return therapy;
        }

        public Collection<Therapy> toModel(Collection<TherapyDTO> dtos)
        {
            return new Collection<Therapy>(dtos
                .Select<TherapyDTO, Therapy>((therapyDTO) => this.toModel(therapyDTO))
                .ToList<Therapy>());
        }
    }
}
