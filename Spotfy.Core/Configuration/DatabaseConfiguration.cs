﻿using Microsoft.Extensions.Configuration;

namespace Spotfy.Core.Configuration
{
    public static class DatabaseConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("Default");
            }
        }
    }
}
