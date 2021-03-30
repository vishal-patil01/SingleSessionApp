using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingleSession.ModelLayer.Configurations
{
    public static class ConfigurationManager
    {
        public static IOptions<ConfigurationProperties> AppConfig { get; set; }
        public static string ConnectionString { get { return AppConfig.Value.ConnectionString; } }

    }
}
