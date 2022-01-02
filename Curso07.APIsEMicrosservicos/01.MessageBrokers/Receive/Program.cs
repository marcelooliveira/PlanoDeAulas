using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receive
{
    class Program
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "minha-fila", durable: false, exclusive: false, autoDelete: false, arguments: null);

                Console.WriteLine(" [*] Aguardando mensagens.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] MENSAGEM RECEBIDA: {0}", message);
                };
                channel.BasicConsume(queue: "minha-fila", autoAck: true, consumer: consumer);

                Console.WriteLine(" Tecle [enter] para sair.");
                Console.ReadLine();
            }
        }
    }
}
