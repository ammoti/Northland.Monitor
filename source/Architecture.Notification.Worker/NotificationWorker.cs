using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Architecture.Application;
using Architecture.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Architecture.Notification.Worker
{
    public class NotificationWorker : BackgroundService
    {
        private readonly ILogger<NotificationWorker> _logger;
        public IServiceProvider _services;

        public NotificationWorker(ILogger<NotificationWorker> logger, IServiceProvider services)
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
                        var targetApp = scope.ServiceProvider.GetRequiredService<INotificationService>();
                        var targetAppList = await targetApp.ListNotificationWaitedAsync();
                        if (targetAppList.Count() == 0)
                            _logger.LogInformation("There is not found and notification : {time}", DateTimeOffset.Now);

                        foreach (var item in targetAppList)
                        {
                            var res = await SendNotification(item);
                            _logger.LogInformation("Notification is sended?: {status}", res);
                            if (res)
                                item.State = (int)NotificationState.Sended;
                            else
                                item.State = (int)NotificationState.Fail;
                            await targetApp.UpdateAsync(item);
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

        private async Task<bool> SendNotification(Model.NotificationModel item)
        {
            switch (item.Type)
            {
                case (int)NotificationType.Email:
                    return await SendEmail(item.ContactTo, item.Message);

                default:
                    return false;
            }
        }

        private async Task<bool> SendEmail(string contactTo, string message)
        {
            _logger.LogInformation($"An email will be send to {contactTo}.");
            try
            {
                //Email Sender Will Implement
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
            }

            return false;
        }
    }
}
