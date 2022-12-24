using IntegrationLibrary.Core.Model.DTO;

namespace IntegrationAPI.Connections.Interface
{
    public interface IHospitalRabbitMqPublisher
    {
        public void SendBloodUnitRequest(BloodUnitRequestDTO bloodUnitRequestDTO);
        public void SendMonthlySubscriptionOffer(MonthlySubscriptionMessageDTO monthlySubscriptionDTO, string routingKey);

    }
}
