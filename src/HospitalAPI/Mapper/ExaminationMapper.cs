using HospitalAPI.Web.Dto;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace HospitalAPI.Web.Mapper
{
    public class ExaminationMapper : IMapper<Examination, ExaminationDTO>
    {
        public ExaminationDTO toDTO(Examination examination)
        {
            var examinationDto = new ExaminationDTO();
            examinationDto.Id = examination.Id;
            examinationDto.PatientId = examination.PatientId;
            examinationDto.DoctorId = examination.DoctorId;
            examinationDto.PatientFullName = examination.Patient.FullName;
            examinationDto.StartTime = examination.DateRange.Start;
            examinationDto.Duration = examination.DateRange.DurationInMinutes;

            return examinationDto;
        }

        public Collection<ExaminationDTO> toDTO(Collection<Examination> models)
        {
            return new Collection<ExaminationDTO>(models
                .Select<Examination, ExaminationDTO>((examination) => this.toDTO(examination))
                .ToList<ExaminationDTO>());
        }

        public Examination toModel(ExaminationDTO dto)
        {
            Examination examination = new Examination();
            if (dto.Id.HasValue)
            {
                examination.Id = dto.Id.Value;
            }
            examination.DoctorId = dto.DoctorId;
            examination.PatientId = dto.PatientId;
            examination.DateRange = dto.DateRange;

            return examination;
        }

        public Collection<Examination> toModel(Collection<ExaminationDTO> dtos)
        {
            return (Collection<Examination>)dtos
                .Select<ExaminationDTO, Examination>(dto => this.toModel(dto));
        }
    }
}