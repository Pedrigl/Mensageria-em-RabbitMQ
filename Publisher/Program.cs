using System;
using System.Reflection.Emit;
using System.Text;
using RabbitMQ.Client;

namespace publisher
{
    internal class Enviar
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            Label:
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "PedroTeste", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    string message = Console.ReadLine();
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "PedroTeste", basicProperties: null, body: body);
                }

                Console.ReadLine();
                goto Label;
            }
        }
    }
}
