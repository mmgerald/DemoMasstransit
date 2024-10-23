using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Consumer.Consumers;

internal class GettingStartedConsumer(ILogger<GettingStartedConsumer> logger) :
    IConsumer<GettingStarted>
{
    public Task Consume(ConsumeContext<GettingStarted> context)
    {
        // Consume gets called for messages in the queue
        // Without further configuration, exceptions will result in rabbitmq 
        // to be stored in the error queue. 
        // https://masstransit.io/documentation/concepts/consumers
        logger.LogInformation("Received Text: {Text}", context.Message.Value);
        return Task.CompletedTask;
    }
}