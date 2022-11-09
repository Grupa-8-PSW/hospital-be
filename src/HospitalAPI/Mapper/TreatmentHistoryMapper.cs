﻿using HospitalAPI.DTO;
using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using System.Collections.ObjectModel;
using System.Globalization;

namespace HospitalAPI.Mapper
{
    public class TreatmentHistoryMapper : IMapper<TreatmentHistory, TreatmentHistoryDTO>
    {
        public TreatmentHistoryDTO toDTO(TreatmentHistory treatmentHistory)
        {
            TreatmentHistoryDTO treatmentHistoryDTO = new TreatmentHistoryDTO();
            treatmentHistoryDTO.Id = treatmentHistory.Id;
            treatmentHistoryDTO.StartDate = treatmentHistory.StartDate;
            treatmentHistoryDTO.EndDate = treatmentHistory.EndDate;
            treatmentHistoryDTO.Active = treatmentHistory.Active;
            treatmentHistoryDTO.DischargeReason = treatmentHistory.DischargeReason;
            treatmentHistoryDTO.PatientId = treatmentHistory.PatientId;
            treatmentHistoryDTO.BedId = treatmentHistory.BedId;
            treatmentHistoryDTO.Reason = treatmentHistory.Reason;
            return treatmentHistoryDTO;
        }

        public Collection<TreatmentHistoryDTO> toDTO(Collection<TreatmentHistory> models)
        {
            return (Collection<TreatmentHistoryDTO>)models
                .Select<TreatmentHistory, TreatmentHistoryDTO>((treatmentHistory) => this.toDTO(treatmentHistory));
        }

        public TreatmentHistory toModel(TreatmentHistoryDTO dto)
        {
            TreatmentHistory treatmentHistory = new TreatmentHistory();
            if (dto.Id.HasValue)
            {
                treatmentHistory.Id = dto.Id.Value;
            }
            treatmentHistory.StartDate = dto.StartDate; 
            treatmentHistory.EndDate = dto.EndDate;
            //examination.StartTime = DateTime.ParseExact(dto.StartTime, "dd/MM/yyyy HH:mm", null); //DateTime.Parse(dto.StartTime, null, System.Globalization.DateTimeStyles.RoundtripKind);

            treatmentHistory.Active = dto.Active;
            treatmentHistory.DischargeReason = dto.DischargeReason;
            //Therapies? Patient? Bed?
            treatmentHistory.PatientId = dto.PatientId;
            treatmentHistory.BedId = dto.BedId;
            treatmentHistory.Reason = dto.Reason;

            return treatmentHistory;
        }

        public Collection<TreatmentHistory> toModel(Collection<TreatmentHistoryDTO> dtos)
        {
            return (Collection<TreatmentHistory>)dtos
                .Select<TreatmentHistoryDTO, TreatmentHistory>(dto => this.toModel(dto));
        }
    }
}