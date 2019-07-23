using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AutoCompleteIgnored
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [FunctionName("Function1")]
        public async Task Run(
            [ServiceBusTrigger("testqueue", Connection = "ServiceBusConnectionString")]Message message,
            MessageReceiver messageReceiver)
        {
            await messageReceiver.CompleteAsync(message.SystemProperties.LockToken);


            await Task.Delay(70 * 1000);

            _logger.LogInformation($"C# ServiceBus queue trigger function processed message: {message.MessageId}");
        }
    }
}
