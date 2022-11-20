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
            bloodUnitRequestDTO.Type = model.Type.ToString();
            bloodUnitRequestDTO.Amount = model.AmountL;
            bloodUnitRequestDTO.Reason = model.Reason;
            bloodUnitRequestDTO.CreationDate = model.CreationDate.ToString("dd/MM/yyyy HH:mm");
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
            BloodType bloodType;
            if (!Enum.TryParse<BloodType>(dto.Type, out bloodType))
            {
                return null;
            }
            bloodUnitRequest.Type = bloodType;
            bloodUnitRequest.AmountL = dto.Amount;
            bloodUnitRequest.Reason = dto.Reason;
            bloodUnitRequest.CreationDate = DateTime.ParseExact(dto.CreationDate, "dd/MM/yyyy", null).ToUniversalTime();  
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
