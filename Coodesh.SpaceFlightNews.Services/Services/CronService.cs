using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coodesh.SpaceFlightNews.Services
{
    public class CronService : IJob
    {
        private readonly ILogger<CronService> _logger;
        public CronService(ILogger<CronService> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello world!");
            return Task.CompletedTask;
        }
    }
}
