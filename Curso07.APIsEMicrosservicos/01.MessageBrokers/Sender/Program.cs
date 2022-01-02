using RabbitMQ.Client;
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

                string message = "Saudações, eu vim do projeto Aula01.Send!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "minha-fila", basicProperties: null, body: body);
                Console.WriteLine(" [x] MENSAGEM ENVIADA: {0}", message);
            }

            Console.WriteLine(" Tecle [enter] para saiur.");
            Console.ReadLine();
        }
    }
}
