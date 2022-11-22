using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace HospitalAPI.Mapper
{
    public class BloodUnitRequestMapper : IMapper<BloodUnitRequest, BloodUnitRequestDTO>
    {
        public BloodUnitRequestDTO toDTO(BloodUnitRequest model)
        {
            var bloodUnitRequestDTO = new BloodUnitRequestDTO();
            bloodUnitRequestDTO.Id = model.Id;
            bloodUnitRequestDTO.DoctorId = model.DoctorId;
            bloodUnitRequestDTO.Type = model.Type.ToString();
            bloodUnitRequestDTO.AmountL = model.AmountL;
            bloodUnitRequestDTO.Reason = model.Reason;
            bloodUnitRequestDTO.CreationDate = model.CreationDate.ToString("dd/MM/yyyy HH:mm");
            bloodUnitRequestDTO.ManagerComment = model.ManagerComment;
            bloodUnitRequestDTO.Status = model.Status;
            return bloodUnitRequestDTO;
        }

        public Collection<BloodUnitRequestDTO> toDTO(Collection<BloodUnitRequest> models)
        {
            return new Collection<BloodUnitRequestDTO>(models
                .Select<BloodUnitRequest, BloodUnitRequestDTO>((bloodUnitRequest) => this.toDTO(bloodUnitRequest))
                .ToList<BloodUnitRequestDTO>());
        }

        public BloodUnitRequest toModel(BloodUnitRequestDTO dto)
        {
            BloodUnitRequest bloodUnitRequest = new BloodUnitRequest();
            if (dto.Id.HasValue)
            {
                bloodUnitRequest.Id = dto.Id.Value;
            }
            if (dto.DoctorId.HasValue)
            {
                bloodUnitRequest.DoctorId = dto.DoctorId.Value;
            }
            BloodType bloodType;
            if (!Enum.TryParse<BloodType>(dto.Type, out bloodType))
            {
                return null;
            }
            bloodUnitRequest.Type = bloodType;
            bloodUnitRequest.AmountL = dto.AmountL;
            bloodUnitRequest.Reason = dto.Reason;
            bloodUnitRequest.CreationDate = DateTime.ParseExact(dto.CreationDate, "dd/MM/yyyy", null).ToUniversalTime();
            bloodUnitRequest.ManagerComment = dto.ManagerComment;
            bloodUnitRequest.Status = dto.Status;
            return bloodUnitRequest;
        }

        public Collection<BloodUnitRequest> toModel(Collection<BloodUnitRequestDTO> dtos)
        {
            return new Collection<BloodUnitRequest>(dtos
                .Select<BloodUnitRequestDTO, BloodUnitRequest>((bloodUnitRequestDTO) => this.toModel(bloodUnitRequestDTO))
                .ToList<BloodUnitRequest>());
        }
    }
}
