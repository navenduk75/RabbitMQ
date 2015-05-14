using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQ
{
    class Send
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello",false,false,false,null);

                    string message = "Hello World";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("","hello",null,body);
                    Console.WriteLine("[x] sent {0}",message);
                    Console.ReadLine();
                }
            }
        }
    }
}
