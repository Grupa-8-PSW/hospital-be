using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Model;
using System.Collections.ObjectModel;

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
            throw new NotImplementedException();
        }

        public Collection<Blood> toModel(Collection<BloodDTO> dtos)
        {
            throw new NotImplementedException();
        }
    }
}
