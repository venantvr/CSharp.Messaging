using System;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //amqp://jbdbwalf:yjvIz693KEujs96ws4vlSA1sI3uaDklW@moose.rmq.cloudamqp.com/jbdbwalf

            Publish();
        }

        public static void Publish()
        {
            // create a connection and open a channel, dispose them when done
            using (var conn = ConnFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                // The message we want to put on the queue
                var message = DateTime.Now.ToString("F");
                // the data put on the queue must be a byte array
                var data = Encoding.UTF8.GetBytes(message);
                // ensure that the queue exists before we publish to it
                var queueName = "queue1";
                var durable = true;
                var exclusive = false;
                var autoDelete = false;
                channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);
                // publish to the "default exchange", with the queue name as the routing key
                var exchangeName = "";
                var routingKey = "queue1";
                channel.BasicPublish(exchangeName, routingKey, null, data);
            }
            //return new EmptyResult();
        }

        private static readonly string url =
            @"amqp://tlcswhrf:HTaEhnLDKWizDJNlWao9eLG9QDNXbp9r@white-swan.rmq.cloudamqp.com/tlcswhrf";

        // ConfigurationManager.AppSettings["CLOUDAMQP_URL"];

        // Create a ConnectionFactory and set the Uri to the CloudAMQP url
        // the connectionfactory is stateless and can safetly be a static resource in your app
        private static readonly ConnectionFactory ConnFactory = new ConnectionFactory
                                                                {
                                                                    Uri = url.Replace("amqp://", "amqps://")
                                                                };
    }
}