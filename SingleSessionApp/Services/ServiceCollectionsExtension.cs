﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SingleSession.BusinessLayer.Implementation;
using SingleSession.BusinessLayer.Interface;
using SingleSession.DataAccessLayer.Implementation;
using SingleSession.DataAccessLayer.Interface;
using SingleSession.ModelLayer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleSessionApp.Services
{
    public static class ServiceCollectionsExtension
    {
        public static IServiceCollection SetupDependancy(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConfigurationProperties>(configuration.GetSection("ConfigurationSettings"));
            ConfigurationManager.AppConfig = services.BuildServiceProvider().GetService<IOptions<ConfigurationProperties>>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
