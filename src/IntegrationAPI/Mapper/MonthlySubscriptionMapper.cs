using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Model;
using static IntegrationAPI.Mapper.IMapper;
using System.Collections.ObjectModel;

namespace IntegrationAPI.Mapper
{
    public class MonthlySubscriptionMapper : IMapper<MonthlySubscription, MonthlySubscriptionDTO>
    {
        public MonthlySubscriptionDTO toDTO(MonthlySubscription model)
        {
            throw new NotImplementedException();
        }

        public Collection<MonthlySubscriptionDTO> toDTO(Collection<MonthlySubscription> models)
        {
            throw new NotImplementedException();
        }

        public MonthlySubscription toModel(MonthlySubscriptionDTO dto)
        {
            MonthlySubscription monthlySubscription = new MonthlySubscription(
                dto.Id,
                dto.RequestedBlood,
                dto.DeliveryDate,
                dto.Bank,
                dto.BankId,
                dto.Status
                );
            return monthlySubscription;
        }

        public Collection<MonthlySubscription> toModel(Collection<MonthlySubscriptionDTO> dtos)
        {
            throw new NotImplementedException();
        }
    }
}
