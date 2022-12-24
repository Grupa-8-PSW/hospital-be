using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;

namespace IntegrationLibrary.Core.Service.Interfaces;

public interface IMonthlySubscriptionService
{
    IEnumerable<MonthlySubscription> GetAll();

    void Create(MonthlySubscription subscription);

    MonthlySubscription GetLast();

    void ChangeStatus(MonthlySubscriptionResponseDTO subscriptionResponse);
    List<BloodDTO> GetBloodIfDelivered(MonthlySubscriptionDeliveryDTO message);
}