using System;
using System.Threading.Tasks;
using Contracts;
using MassTransit;

namespace MassTransitClient
{
    public class MySubscriber
    {
        private readonly IBusControl _bus;

        public MySubscriber()
        {
            MessageHandler<YourMessage1> p = context => NewMethod1(context);
            MessageHandler<YourMessage2> q = context => NewMethod2(context);

            _bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
                                                   {
                                                       var host =
                                                           sbc.Host(
                                                               new Uri(
                                                                   @"amqp://tlcswhrf:HTaEhnLDKWizDJNlWao9eLG9QDNXbp9r@white-swan.rmq.cloudamqp.com/tlcswhrf"),
                                                               h =>
                                                               {
                                                                   h.Username("tlcswhrf");
                                                                   h.Password("HTaEhnLDKWizDJNlWao9eLG9QDNXbp9r");
                                                               });

                                                       sbc.ReceiveEndpoint(host, "sandbox",
                                                           ep =>
                                                           {
                                                               ep.Handler(p);
                                                               ep.Handler(q);
                                                           });
                                                   });

            _bus.Start();
        }

        private static Task NewMethod2(ConsumeContext<YourMessage2> context) => Console.Out.WriteLineAsync(string.Format("Received YourMessage2: {0}", context.Message.Text));

        private static Task NewMethod1(ConsumeContext<YourMessage1> context) => Console.Out.WriteLineAsync(string.Format("Received YourMessage1: {0} {1} {2}", context.Message.Text, context.Message.Date, context.Message.CorrelationId));
    }
}