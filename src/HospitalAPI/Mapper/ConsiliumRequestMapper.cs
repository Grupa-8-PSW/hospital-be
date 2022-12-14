using HospitalAPI.DTO;
using HospitalAPI.Web.Dto;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.ValueObjects;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;


namespace HospitalAPI.Mapper
{
    public class ConsiliumRequestMapper : IMapper<ConsiliumRequest, ConsiliumRequestDTO>
    {
        public ConsiliumRequestDTO toDTO(ConsiliumRequest model)
        {
            var consiliumRequestDTO = new ConsiliumRequestDTO();
            consiliumRequestDTO.Subject = model.Subject;
            consiliumRequestDTO.FromDate = model.Interval.From.ToString("dd/MM/yyyy");
            consiliumRequestDTO.ToDate = model.Interval.To.ToString("dd/MM/yyyy");
            consiliumRequestDTO.Duration = model.Duration;
            consiliumRequestDTO.IsDoctors = model.IsDoctors;
            consiliumRequestDTO.DoctorIds = model.DoctorIds;

            if (model.DoctorSpecializationsWanted != null)
            {
                List<string> doctorSpecializationsWanted = new List<string>();
                foreach(DoctorSpecialization doctorSpecialization in model.DoctorSpecializationsWanted)
                {
                    doctorSpecializationsWanted.Add(doctorSpecialization.ToString());
                }
                consiliumRequestDTO.DoctorSpecializationsWanted = doctorSpecializationsWanted;
            }
            else
            {
                consiliumRequestDTO.DoctorSpecializationsWanted = null;
            }

            return consiliumRequestDTO;
        }

        public Collection<ConsiliumRequestDTO> toDTO(Collection<ConsiliumRequest> models)
        {
            return new Collection<ConsiliumRequestDTO>(models
                .Select<ConsiliumRequest, ConsiliumRequestDTO>((consiliumRequest) => this.toDTO(consiliumRequest))
                .ToList<ConsiliumRequestDTO>());
        }

        public ConsiliumRequest toModel(ConsiliumRequestDTO dto)
        {
            ConsiliumRequest consiliumRequest = new ConsiliumRequest();

            consiliumRequest.Subject = dto.Subject;
            DateTime from = DateTime.ParseExact(dto.FromDate, "dd/MM/yyyy", null);
            DateTime to = DateTime.ParseExact(dto.ToDate, "dd/MM/yyyy", null);
            DateRange dateRange = new DateRange(from, to);
            consiliumRequest.Duration = dto.Duration;
            consiliumRequest.IsDoctors = dto.IsDoctors;
            consiliumRequest.DoctorIds = dto.DoctorIds;
            if (dto.DoctorSpecializationsWanted != null)
            {
                List<DoctorSpecialization> doctorSpecializationsWanted = new List<DoctorSpecialization>();
                foreach (string doctorSpecialization in dto.DoctorSpecializationsWanted)
                {
                    DoctorSpecialization doctorSpecializationTryParse;
                    if (!Enum.TryParse<DoctorSpecialization>(doctorSpecialization, out doctorSpecializationTryParse))
                    {
                        return null;
                    }
                    doctorSpecializationsWanted.Add(doctorSpecializationTryParse);
                }
                consiliumRequest.DoctorSpecializationsWanted = doctorSpecializationsWanted;
            }
            else
            {
                consiliumRequest.DoctorSpecializationsWanted = null;
            }

            return consiliumRequest;
        }

        public Collection<ConsiliumRequest> toModel(Collection<ConsiliumRequestDTO> dtos)
        {
            return new Collection<ConsiliumRequest>(dtos
              .Select<ConsiliumRequestDTO, ConsiliumRequest>((consiliumRequestDTO) => this.toModel(consiliumRequestDTO))
              .ToList<ConsiliumRequest>());
        }
    }
}
