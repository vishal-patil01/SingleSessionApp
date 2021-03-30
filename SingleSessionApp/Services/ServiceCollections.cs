using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SingleSession.ModelLayer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleSessionApp.Services
{
    public static class IServiceCollectionsExtension
    {
        public static IServiceCollection SetupDependancy(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConfigurationProperties>(configuration.GetSection("ConfigurationSettings"));
            ConfigurationManager.AppConfig = services.BuildServiceProvider().GetService<IOptions<ConfigurationProperties>>();
            return services;
        }
    }
}
