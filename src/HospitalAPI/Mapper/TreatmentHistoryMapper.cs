using HospitalAPI.DTO;
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
            treatmentHistoryDTO.StartDate = treatmentHistory.StartDate.ToString("d", CultureInfo.InvariantCulture);
            treatmentHistoryDTO.EndDate = treatmentHistory.EndDate?.ToString("d", CultureInfo.InvariantCulture);
            treatmentHistoryDTO.Active = treatmentHistory.Active;
            treatmentHistoryDTO.DischargeReason = treatmentHistory.DischargeReason;
            treatmentHistoryDTO.PatientId = treatmentHistory.PatientId;
            treatmentHistoryDTO.BedId = treatmentHistory.BedId;
            treatmentHistoryDTO.RoomId = treatmentHistory.Bed.RoomId;
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

          //  treatmentHistory.StartDate = DateTime.ParseExact(dto.StartDate, "dd/MM/yyyy", null); //DateTime.Parse(dto.StartTime, null, System.Globalization.DateTimeStyles.RoundtripKind);
          //  treatmentHistory.EndDate = DateTime.ParseExact(dto.EndDate, "dd/MM/yyyy", null); 
            treatmentHistory.Active = (dto.Active == null) ? false : true;
            treatmentHistory.DischargeReason = (dto.DischargeReason == null) ? "" : dto.DischargeReason;
            //Therapies? Patient? Bed?
            treatmentHistory.PatientId = dto.PatientId;
            treatmentHistory.BedId = (dto.BedId == null) ? 0 : dto.BedId.Value;
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