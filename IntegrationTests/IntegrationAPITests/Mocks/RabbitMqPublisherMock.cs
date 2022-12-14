using IntegrationLibrary.Core.Model.DTO;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.IntegrationAPITests.Mocks
{
    public static class RabbitMqPublisherMock
    {
        public static void Send(BloodBankNewsMessageDTO message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hospitalQueue",
                                      durable: false,
                                      exclusive: false,
                                      autoDelete: false,
                                      arguments: null);
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                
                channel.BasicPublish(exchange: "",
                                     routingKey: "hospitalQueue",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
