using EasyNetQ;
using Messages;
using System;

namespace ShippingPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("[ShippingRoute]Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine())?.ToUpper() != "QUIT")
                {
                    bus.Publish(new TextMessage { Text = input }, "ShippingRoute");
                }
            }
        }
    }
}
