﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Core.Configuration
{
    public static class EmailConfiguration
    {
        public static string Email { get => GetConfiguration().GetSection("EmailSettings:Email").Value; }
        public static string Password { get => GetConfiguration().GetSection("EmailSettings:Password").Value; }
        public static string Smtp { get => GetConfiguration().GetSection("EmailSettings:Smtp").Value; }
        public static int Port { get => Convert.ToInt32(GetConfiguration().GetSection("EmailSettings:Port").Value); }

        private static ConfigurationManager GetConfiguration()
        {
            ConfigurationManager configurationManager = new();

            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager;
        }
    }
}
