using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsertQueueMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var queueClient = new QueueClient("Endpoint=sb://moffmo.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=HaZ3T6qSdfuWnfVs4a1zXT2jUKenjnIrE6V60f8kfTE=", "testqueue");

            var input = "";

            do
            {
                IEnumerable<Task> SendMessages()
                {
                    for (int i = 0; i < 250; i++)
                    {
                        yield return queueClient.SendAsync(new Message());
                    }
                }

                Task.WhenAll(SendMessages()).Wait();

            } while (input != "Q");
        }
    }
}
