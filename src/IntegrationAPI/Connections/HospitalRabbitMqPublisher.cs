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
        private readonly IConfiguration _config;

        public HospitalRabbitMqPublisher(IConfiguration config)
        {
            _config = config;
        }

        public void SendBloodUnitRequest(BloodUnitRequestDTO bloodUnitRequestDTO)
        {
            BloodUnitRequestMessageDTO message =  BloodUnitRequestMessageMapper.ToMessage(bloodUnitRequestDTO);
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                string exchange = _config.GetSection("bloodRequestExchange").Value;
                string routingKey = _config.GetSection("bloodRequestRoutingKey").Value;
                channel.BasicPublish(exchange: exchange,
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);
            }
        }

        public void SendMonthlySubscriptionOffer(MonthlySubscriptionMessageDTO monthlySubscriptionDTO, string routingKey)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: routingKey,
                                      durable: false,
                                      exclusive: false,
                                      autoDelete: false,
                                      arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(monthlySubscriptionDTO));

                channel.BasicPublish(exchange: "",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
