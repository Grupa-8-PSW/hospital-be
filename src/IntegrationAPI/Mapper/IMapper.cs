using System.Collections.ObjectModel;

namespace IntegrationAPI.Mapper
{
    public interface IMapper
    {
        public interface IMapper<Model, DTO>
        {
            DTO toDTO(Model model);
            Model toModel(DTO dto);
            Collection<DTO> toDTO(Collection<Model> models);
            Collection<Model> toModel(Collection<DTO> dtos);
        }
    }
}
