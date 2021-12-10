using Coodesh.SpaceFlightNews.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coodesh.SpaceFlightNews.Jobs
{
    public class UpdateDatabaseJob : IJob
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _provider;
        private readonly ILogger<UpdateDatabaseJob> _logger;

        public UpdateDatabaseJob(IConfiguration configuration, IServiceProvider provider, ILogger<UpdateDatabaseJob> logger)
        {
            this._configuration = configuration;
            this._provider = provider;
            this._logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.Log(LogLevel.Information, "Start UpdateDatabaseJob Execute");
            using (var scope = _provider.CreateScope())
            {
                var articleService = scope.ServiceProvider.GetService<IArticleService>();
                var getDataService = scope.ServiceProvider.GetService<IDataFromAPIService>();

                try
                {
                    var response = await getDataService.GetRequestAsync<IEnumerable<ViewModel.Article>>(_configuration["UpdateDatabaseRequestUri"]);
                    if (response.IsSuccessStatusCode)
                        await articleService.AddNew(response.Item);

                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, "Error UpdateDatabaseJob Execute");
                    await getDataService.AlertError<object>(_configuration["Telegram:Token"], _configuration["Telegram:Channel"], $"Error UpdateDatabaseJob Execute:\r\n\r\n{ex.Message}");
                }
                finally
                {
                    _logger.Log(LogLevel.Information, "Finish UpdateDatabaseJob Execute");
                }
            }
        }
    }
}
