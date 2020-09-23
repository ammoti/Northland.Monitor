using Architecture.Application;
using Architecture.Database;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCore.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Worker
{
    public static class Extensions
    {
        public static void AddContext(this IServiceCollection services)
        {
            var connectionString = "Server=.;Database=northland-downtimer;User Id=sa;Password=Objectx04081991;";
            services.AddContext<Context>(options => options.UseSqlServer(connectionString));
            services.AddUnitOfWork<Context>();
        }

        public static void AddSecurity(this IServiceCollection services)
        {
            services.AddHash();
            services.AddJsonWebToken(Guid.NewGuid().ToString(), TimeSpan.FromHours(12));
            // services.AddAuthenticationJwtBearer();
        }

        public static void AddServices(this IServiceCollection services)
        {
            // services.AddFileExtensionContentTypeProvider();
            services.AddClassesInterfaces(typeof(ITargetAppService).Assembly);
            services.AddClassesInterfaces(typeof(ITargetAppRepository).Assembly);
            services.AddClassesInterfaces(typeof(IUnitOfWork).Assembly);
        }
       
    }
}
