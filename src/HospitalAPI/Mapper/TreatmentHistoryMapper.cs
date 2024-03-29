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
            IMapper<Patient, PatientDTO> patientMapper = new PatientMapper();

            TreatmentHistoryDTO treatmentHistoryDTO = new TreatmentHistoryDTO();
            treatmentHistoryDTO.Id = treatmentHistory.Id;
            treatmentHistoryDTO.StartDate = treatmentHistory.StartDate.ToString("d", CultureInfo.InvariantCulture);
            treatmentHistoryDTO.EndDate = treatmentHistory.EndDate?.ToString("d", CultureInfo.InvariantCulture);
            treatmentHistoryDTO.Active = treatmentHistory.Active;
            treatmentHistoryDTO.DischargeReason = treatmentHistory.DischargeReason;
            treatmentHistoryDTO.PatientId = treatmentHistory.PatientId;
            treatmentHistoryDTO.Patient = patientMapper.toDTO(treatmentHistory.Patient);
            treatmentHistoryDTO.BedId = treatmentHistory.BedId;
            treatmentHistoryDTO.RoomId = treatmentHistory.RoomId;
            treatmentHistoryDTO.Reason = treatmentHistory.Reason;
            return treatmentHistoryDTO;
        }

        public Collection<TreatmentHistoryDTO> toDTO(Collection<TreatmentHistory> models)
        {
            return new Collection<TreatmentHistoryDTO>(models
                .Select<TreatmentHistory, TreatmentHistoryDTO>((treatmentHistory) => this.toDTO(treatmentHistory)).ToList());
        }

        public TreatmentHistory toModel(TreatmentHistoryDTO dto)
        {
            TreatmentHistory treatmentHistory = new TreatmentHistory();
            if (dto.Id.HasValue)
            {
                treatmentHistory.Id = dto.Id.Value;
            }

            treatmentHistory.StartDate = (dto.StartDate == null) ? new DateTime() : DateTime.ParseExact(dto.StartDate, "MM/dd/yyyy", null); //DateTime.Parse(dto.StartTime, null, System.Globalization.DateTimeStyles.RoundtripKind);
            treatmentHistory.EndDate = (dto.EndDate == null) ? null : DateTime.ParseExact(dto.EndDate, "MM/dd/yyyy", null); 
            treatmentHistory.Active = (dto.Active == null) ? false : true;
            treatmentHistory.DischargeReason = (dto.DischargeReason == null) ? "" : dto.DischargeReason;
            //Therapies? Patient? Bed?
            treatmentHistory.PatientId = dto.PatientId;
            treatmentHistory.BedId = (dto.BedId == null) ? 0 : dto.BedId.Value;
            treatmentHistory.RoomId = dto.RoomId;
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