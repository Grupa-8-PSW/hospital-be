using IntegrationLibrary.Core.Model;
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
        public static void Send()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "news",
                                      durable: false,
                                      exclusive: false,
                                      autoDelete: false,
                                      arguments: null);
                BloodBankNews message = new BloodBankNews("text1", "subject1", 2, Array.Empty<byte>(), false, false);
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                
                channel.BasicPublish(exchange: "",
                                     routingKey: "news",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
