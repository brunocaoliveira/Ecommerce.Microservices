using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Sales.API.Services
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            // 1. Conectar ao servidor RabbitMQ (rodando localmente)
            var factory = new ConnectionFactory { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // 2. Garantir que a fila exista
                // A fila é onde as mensagens são armazenadas até serem consumidas.
                // Daremos um nome a ela, ex: "orders"
                channel.QueueDeclare(queue: "orders",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // 3. Serializar a mensagem para JSON
                var jsonString = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(jsonString);

                // 4. Publicar a mensagem na fila
                channel.BasicPublish(exchange: "",
                                     routingKey: "orders", // O nome da fila
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}