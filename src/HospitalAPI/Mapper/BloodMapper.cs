using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using HospitalLibrary.Core.Enums;

namespace HospitalAPI.Mapper
{
    public class BloodMapper : IMapper<Blood, BloodDTO>
    {
        public BloodDTO toDTO(Blood model)
        {
            var bloodDTO = new BloodDTO();
            bloodDTO.Id = model.Id;
            bloodDTO.Quantity = model.Quantity;
            bloodDTO.Type = model.Type.ToString();

            return bloodDTO;
        }

        public Collection<BloodDTO> toDTO(Collection<Blood> models)
        {
            return new Collection<BloodDTO>(models
                .Select<Blood, BloodDTO>((blood) => this.toDTO(blood))
                .ToList<BloodDTO>());
        }

        public Blood toModel(BloodDTO dto)
        {
            Blood blood = new Blood();
            if (dto.Id != null)
            {
                blood.Id = dto.Id;
            }

            BloodType bloodType;
            if (!Enum.TryParse<BloodType>(dto.Type, out bloodType))
            {
                return null;
            }

            blood.Type = bloodType;
            blood.Quantity = dto.Quantity;

            return blood;
        }

        public Collection<Blood> toModel(Collection<BloodDTO> dtos)
        {
            return new Collection<Blood>(dtos
                .Select<BloodDTO, Blood>((bloodDto) => this.toModel(bloodDto))
                .ToList());
        }
    }
}
