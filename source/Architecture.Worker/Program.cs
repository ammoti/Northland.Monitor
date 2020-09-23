using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Application;
using Architecture.Database;
using DotNetCore.IoC;
using DotNetCore.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Architecture.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).UseSerilog().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    //.UseWindowsService() // this is for windows service
                    //.UseSystemd() // this is for linux service
                    .ConfigureServices((hostContext, services) =>
                    {
                        //var configuration = hostContext.Configuration;
                        //services.AddDbContext<Context>(options =>
                        //    options.UseSqlServer(
                        //        configuration.GetConnectionString("Context")));
                        services.AddContext();
                        services.AddSecurity();
                        services.AddServices();
                        services.AddTransient<ITargetAppService, TargetAppService>();
                        services.AddHostedService<MonitorWorker>();

                    });
    }
}
