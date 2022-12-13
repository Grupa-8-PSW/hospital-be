using HospitalAPI.DTO;
using IntegrationAPI.Connections.Interface;
using IntegrationAPI.Mapper;
using IntegrationLibrary.Core.Model.DTO;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using BloodUnitRequestDTO = IntegrationLibrary.Core.Model.DTO.BloodUnitRequestDTO;

namespace IntegrationAPI.Connections
{
    public class HospitalRabbitMqPublisher : IHospitalRabbitMqPublisher
    {
        public void SendBloodUnitRequest(BloodUnitRequestDTO bloodUnitRequestDTO)
        {
            BloodUnitRequestMessageDTO message =  BloodUnitRequestMessageMapper.ToMessage(bloodUnitRequestDTO);
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish(exchange: "bloodRequestExchange",
                                     routingKey: "bloodRequests.randomString",
                                     basicProperties: null,
                                     body: body);
            }
        }

        public void SendMonthlySubscriptionOffer(MonthlySubscriptionDTO monthlySubscriptionDTO)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(monthlySubscriptionDTO));

                channel.BasicPublish(exchange: "",
                                     routingKey: "monthlySubscriptonsRoutingKey29",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
