﻿using HospitalAPI.Web.Dto;
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
            ExaminationDTO examinationDTO = new ExaminationDTO();
            examinationDTO.Id = examination.Id;
            examinationDTO.PatientId = examination.PatientId;
            examinationDTO.DoctorId = examination.DoctorId;
            examinationDTO.StartTime = examination.StartTime.ToString("o", CultureInfo.InvariantCulture);
            examinationDTO.Duration = examination.Duration;

            return examinationDTO;
        }

        public Collection<ExaminationDTO> toDTO(Collection<Examination> models)
        {
            return (Collection<ExaminationDTO>)models
                .Select<Examination, ExaminationDTO>((examination) => this.toDTO(examination));
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
            examination.Duration = dto.Duration;
            examination.StartTime = DateTime.ParseExact(dto.StartTime, "dd/MM/yyyy HH:mm", null); //DateTime.Parse(dto.StartTime, null, System.Globalization.DateTimeStyles.RoundtripKind);

            return examination;
        }

        public Collection<Examination> toModel(Collection<ExaminationDTO> dtos)
        {
            return (Collection<Examination>)dtos
                .Select<ExaminationDTO, Examination>(dto => this.toModel(dto));
        }
    }
}