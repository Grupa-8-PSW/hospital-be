using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using static IntegrationAPI.Mapper.IMapper;

namespace IntegrationAPI.Mapper
{
    public class BloodBankNewsMapper : IMapper<BloodBankNews, BloodBankNewsDTO>
    {
        public BloodBankNewsDTO toDTO(BloodBankNews model)
        {
            BloodBankNewsDTO bloodBankNewsDTO = new BloodBankNewsDTO();
            bloodBankNewsDTO.Id = model.Id;
            bloodBankNewsDTO.BloodBankId = model.BloodBankId;
            bloodBankNewsDTO.Published = model.Published;
            bloodBankNewsDTO.Archived = model.Published;
            bloodBankNewsDTO.Subject = model.Subject;
            bloodBankNewsDTO.Text = model.Text;
            bloodBankNewsDTO.ImgSrc = model.ImgSrc;
            bloodBankNewsDTO.BloodBank = model.BloodBank;
            return bloodBankNewsDTO;
        }

        public Collection<BloodBankNewsDTO> toDTO(Collection<BloodBankNews> models)
        {
            return new Collection<BloodBankNewsDTO>(models
                .Select<BloodBankNews, BloodBankNewsDTO>((bloodUnitRequest) => this.toDTO(bloodUnitRequest))
                .ToList<BloodBankNewsDTO>());
        }

        public BloodBankNews toModel(BloodBankNewsDTO dto)
        {
            BloodBankNews bloodBankNews = new BloodBankNews();
            bloodBankNews.Id = dto.Id;
            bloodBankNews.BloodBankId = dto.BloodBankId;
            bloodBankNews.Published = dto.Published;
            bloodBankNews.Archived = dto.Published;
            bloodBankNews.Subject = dto.Subject;
            bloodBankNews.Text = dto.Text;
            bloodBankNews.ImgSrc = dto.ImgSrc;
            bloodBankNews.BloodBank = dto.BloodBank;
            return bloodBankNews;

        }

        public Collection<BloodBankNews> toModel(Collection<BloodBankNewsDTO> dtos)
        {
            return new Collection<BloodBankNews>(dtos
                .Select<BloodBankNewsDTO, BloodBankNews>((bloodUnitRequestDTO) => this.toModel(bloodUnitRequestDTO))
                .ToList<BloodBankNews>());
        }
    }
}
