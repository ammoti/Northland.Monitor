using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Architecture.Application;
using Architecture.Domain;
using Architecture.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Architecture.Worker
{
    public class MonitorWorker : BackgroundService
    {
        private readonly ILogger<MonitorWorker> _logger;
        public IServiceProvider _services;

        public MonitorWorker(ILogger<MonitorWorker> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
            //   _authService = authService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);


                using (var scope = _services.CreateScope())
                {
                    try
                    {
                        var targetApp = scope.ServiceProvider.GetRequiredService<ITargetAppService>();
                        var checkHistoryService = scope.ServiceProvider.GetRequiredService<ICheckHistoryService>();
                        var targetAppList = await targetApp.GetMonitorTargets(DateTime.Now);
                        if (targetAppList.Count()==0)
                            _logger.LogInformation("There is not found and target : {time}", DateTimeOffset.Now);

                        foreach (var item in targetAppList)
                        {
                            var res = await GetCheckHealth(item);
                            _logger.LogInformation("Target Health Status : {status}", res.MessageCode);
                            await targetApp.UpdateAsync(item);
                            res.TargetAppModel = item;
                            await checkHistoryService.AddAsync(res);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Something wrong check out {message}", ex.Message);
                    }
                }
                await Task.Delay(60 * 1000, stoppingToken);
            }
        }
        public async Task<CheckHistoryModel> GetCheckHealth(TargetAppModel target)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(target.Url);
                    bool isOk = response.IsSuccessStatusCode;
                    return new CheckHistoryModel { CheckDate = DateTime.Now, IsWork = isOk, MessageCode = response.StatusCode.ToString() };
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Target Health Status : {status}", ex.Message);
                return new CheckHistoryModel { CheckDate = DateTime.Now, IsWork = false, MessageCode = "Error" };

            }
        }
    }
}
