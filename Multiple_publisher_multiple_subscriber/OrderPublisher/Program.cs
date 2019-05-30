using EasyNetQ;
using Messages;
using System;

namespace OrderPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost;publisherConfirms=true"))
            {
                var input = "";
                Console.WriteLine("[OrderRoute]Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine())?.ToUpper() != "QUIT")
                {
                    bus.PublishAsync(new TextMessage { Text = input }, "OrderRoute")
                        .ContinueWith(task =>
                        {
                            if (task.IsCompleted)
                            {
                                Console.Out.WriteLine("{0} Completed", task.Status);

                            }
                            if (task.IsFaulted)
                            {
                                Console.Out.WriteLine("\n\n");
                                Console.Out.WriteLine(task.Exception);
                                Console.Out.WriteLine("\n\n");
                            }
                        });
                }
            }
        }
    }
}
