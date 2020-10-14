using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service Started at: {time}", DateTimeOffset.Now);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service Stoped at: {time}", DateTimeOffset.Now);
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (GetResponse())
                {
                    _logger.LogInformation("Response is OK at: {time}", DateTimeOffset.Now);
                }
                else
                {
                    _logger.LogInformation("No Response at: {time}", DateTimeOffset.Now);
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(3000, stoppingToken);
            }
        }

        public bool GetResponse()
        {
            return true; //Here we write our work
        }
    }
}
