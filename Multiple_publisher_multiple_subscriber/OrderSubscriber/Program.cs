using EasyNetQ;
using Messages;
using System;

namespace OrderSubscriber
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<TextMessage>("OrderRoute_Subscription_id", HandleTextMessage, handler => handler.WithTopic("OrderRoute"));

                Console.WriteLine("[OrderRoute]Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleTextMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[OrderRoute]Got message {textMessage.Text}");
        }

    }
}
