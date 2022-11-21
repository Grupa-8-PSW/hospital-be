using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace IntegrationAPI.Connections
{
    public class BloodBankRabbitMqConnection : BackgroundService
    {
        IConnection connection;
        RabbitMQ.Client.IModel channel;
        private readonly IServiceProvider serviceProvider;

        public BloodBankRabbitMqConnection(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory { HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest" };
            connection = factory.CreateConnection();//try catch jer baca error
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "news",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                BloodBankNews message;
                try
                {
                    message = JsonConvert.DeserializeObject<BloodBankNews>(jsonMessage);
                    using(var scope = serviceProvider.CreateScope())
                    {
                        var scopedService = scope.ServiceProvider.GetRequiredService<IBloodBankNewsService>();
                        scopedService.Create(message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            };
            channel.BasicConsume(queue: "news",
                                   autoAck: true,
                                   consumer: consumer);
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
