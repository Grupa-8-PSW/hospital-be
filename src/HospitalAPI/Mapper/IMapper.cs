using System.Collections;
using System.Collections.ObjectModel;

namespace HospitalAPI.Web.Mapper
{
    public interface IMapper<Model, DTO>
    {
        DTO toDTO(Model model);
        Model toModel(DTO dto);
        Collection<DTO> toDTO(Collection<Model> models);
        Collection<Model> toModel(Collection<DTO> dtos);
    }
}