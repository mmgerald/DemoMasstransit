using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Producer;

public class Worker(ILogger<Worker> logger, IBus bus) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {Time}", DateTimeOffset.Now);
            await bus.Publish(new GettingStarted { Value = $"The time is {DateTimeOffset.Now}" }, stoppingToken);

            await Task.Delay(1000, stoppingToken);
        }
    }
}