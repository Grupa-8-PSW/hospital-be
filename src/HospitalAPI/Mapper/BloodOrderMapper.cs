using HospitalAPI.DTO;
using HospitalAPI.Web.Mapper;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Core.Model;
using System.Linq;

namespace HospitalAPI.Mapper
{
    public class BloodOrderMapper : IMapper<MonthlySubscription, BloodOrderDTO>
    {
        public BloodOrderDTO toDTO(MonthlySubscription model)
        {
            throw new NotImplementedException();
        }

        public BloodOrderDTO toDTOBloodType(MonthlySubscription model, BloodType bloodType)
        {
            var bloodDTO = new BloodOrderDTO();
            bloodDTO.DeliveryDate = model.DeliveryDate;
            bloodDTO.BankName = model.Bank.Name;
            bloodDTO.OrderStatus = model.Status;
            bloodDTO.BloodType = bloodType;
            var blood = model.RequestedBlood.FirstOrDefault(rb => rb.BloodType == bloodType);
            bloodDTO.Quantity = (blood == null) ? 0 : blood.Quantity;

            return bloodDTO;
        }

        public IEnumerable<BloodOrderDTO> toDTOBloodType(IEnumerable<MonthlySubscription> models, BloodType bloodType)
        {
            return new Collection<BloodOrderDTO>(models
                .Select<MonthlySubscription, BloodOrderDTO>((blood) => this.toDTO(blood))
                .ToList<BloodOrderDTO>());
        }

        public Collection<BloodOrderDTO> toDTO(Collection<MonthlySubscription> models)
        {
            throw new NotImplementedException();
        }

        public MonthlySubscription toModel(BloodOrderDTO dto)
        {
            throw new NotImplementedException();
        }

        public Collection<MonthlySubscription> toModel(Collection<BloodOrderDTO> dtos)
        {
            throw new NotImplementedException();
        }
    }
}
