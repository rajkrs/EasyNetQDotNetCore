using EasyNetQ;
using Messages;
using System;

namespace ShippingSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<TextMessage>("ShippingRoute_Subscription_id", HandleTextMessage, handler => handler.WithTopic("ShippingRoute"));

                Console.WriteLine("[ShippingRoute]Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleTextMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ShippingRoute]Got message {textMessage.Text}");
        }
    }
}
