using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibrary.Core.Repository;
using IntegrationLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore.Metadata;
using Nancy.Json;
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
            try
            {
                string hospitalQueue;
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                    hospitalQueue = scopedService.GetSection("hospitalQueue").Value;
                }
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
                channel.QueueDeclare(queue: hospitalQueue,
                                      durable: false,
                                      exclusive: false,
                                      autoDelete: false,
                                      arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    byte[] body = ea.Body.ToArray();
                    var jsonMessage = Encoding.UTF8.GetString(body);

                    TryParseBloodBankNews(jsonMessage);
                    TryParseSubscriptionResponse(jsonMessage);
                    TryParseMonthlyBloodDelivery(jsonMessage);
                    TryParseBloodRequestDelivery(jsonMessage);
                };
                channel.BasicConsume(queue: hospitalQueue,
                                       autoAck: true,
                                       consumer: consumer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Task.CompletedTask;
        }

        private void TryParseBloodRequestDelivery(string jsonMessage)
        {
            try
            {
                BloodUnitRequestDeliveryDTO message = JsonConvert.DeserializeObject<BloodUnitRequestDeliveryDTO>(jsonMessage);
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<IHospitalHTTPConnectionService>();
                    scopedService.RestockBloodIfDelivered(message);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void TryParseMonthlyBloodDelivery(string jsonMessage)
        {
            try
            {
                MonthlySubscriptionDeliveryDTO message = JsonConvert.DeserializeObject<MonthlySubscriptionDeliveryDTO>(jsonMessage);
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<IMonthlySubscriptionService>();
                    List<BloodDTO> bloods = scopedService.GetBloodIfDelivered(message);
                    if (bloods.Count() > 0)
                    {
                        var subscriptionService = scope.ServiceProvider.GetRequiredService<IHospitalHTTPConnectionService>();
                        subscriptionService.RestockBlood(bloods);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void TryParseSubscriptionResponse(string jsonMessage)
        {
            try
            {
                MonthlySubscriptionResponseDTO message = JsonConvert.DeserializeObject<MonthlySubscriptionResponseDTO>(jsonMessage);
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<IMonthlySubscriptionService>();
                    scopedService.ChangeStatus(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void TryParseBloodBankNews(string jsonMessage)
        {
            try
            {
                BloodBankNewsMessageDTO message = JsonConvert.DeserializeObject<BloodBankNewsMessageDTO>(jsonMessage);
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<IBloodBankNewsService>();
                    scopedService.Create(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
