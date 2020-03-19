using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Impl;

namespace MyResearch.QueueSender
{
    class Program
    {
        //for pub/sub use 
        //https://www.rabbitmq.com/tutorials/tutorial-three-dotnet.html
        static void Main(string[] args)
        {
            HelloWorldTopic();

            //PubSub();

            //Topics();
        }

        private static void HelloWorldTopic()
        {

            while (true)
            {


                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "myqueue",
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    channel.ExchangeDeclare(exchange: "myexchange",
                                            durable: true,
                                            type: "topic");

                    string message = "Hello World! " + DateTime.Now.Ticks.ToString();
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "myexchange",
                                         routingKey: "my.otherkey",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine("Sent {0}", message);
                }

                Console.ReadKey();
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static void Topics()
        {
            while (true)
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    var argsTtl = new Dictionary<string, object>();
                    argsTtl.Add("x-message-ttl", 60000);
                    channel.ExchangeDeclare(exchange: "topic_logs2",
                        durable: true,
                                            type: "topic", arguments: argsTtl);

                    var routingKey = "xxx.info";
                    string message = "Hello World! " + DateTime.Now.Ticks.ToString();
                    var body = Encoding.UTF8.GetBytes(message);
                    var props = channel.CreateBasicProperties();
                    props.ContentType = "text/plain";
                    props.DeliveryMode = 2;
                    props.Expiration = "36000000";

                    channel.BasicPublish(exchange: "topic_logs",
                                         routingKey: routingKey,

                                         basicProperties: props,
                                         body: body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
                }
                Console.ReadKey();
            }
        }
        private static void PubSub()
        {
            while (true)
            {


                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

                    string message = "Hello World! " + DateTime.Now.Ticks.ToString();
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "logs",
                                         routingKey: "",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
                Console.ReadKey();
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }



        //private static void HelloWorld()
        //{

        //    while (true)
        //    {


        //        var factory = new ConnectionFactory() { HostName = "localhost" };
        //        using (var connection = factory.CreateConnection())
        //        using (var channel = connection.CreateModel())
        //        {
        //            channel.QueueDeclare(queue: "hello2",
        //                                 durable: true,
        //                                 exclusive: false,
        //                                 autoDelete: false,
        //                                 arguments: null);

        //            string message = "Hello World! " + DateTime.Now.Ticks.ToString();
        //            var body = Encoding.UTF8.GetBytes(message);

        //            channel.BasicPublish(exchange: "",
        //                                 routingKey: "hello",
        //                                 basicProperties: null,
        //                                 body: body);
        //            Console.WriteLine(" [x] Sent {0}", message);
        //        }

        //        Console.ReadKey();
        //    }
        //    Console.WriteLine(" Press [enter] to exit.");
        //    Console.ReadLine();
        //}
    }
}
