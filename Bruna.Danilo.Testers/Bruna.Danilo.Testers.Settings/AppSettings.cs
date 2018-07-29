using System;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Bruna.Danilo.Testers.Settings
{
	public static class AppSettings
    {
		private static bool? _LogInfo;

		public static bool LogInfo
        {
            get
            {
                if (!_LogInfo.HasValue)
					_LogInfo = Convert.ToBoolean(Configuration["LogInfo"]);

				return _LogInfo.Value;
            }
        }

        private static string _JwtIssuer;

        public static string JwtIssuer
        {
            get
            {
                if (String.IsNullOrEmpty(_JwtIssuer))
                    _JwtIssuer = Configuration["JwtIssuer"];

                return _JwtIssuer;
            }
        }

        private static string _JwtExpireDays;

        public static string JwtExpireDays
        {
            get
            {
                if (String.IsNullOrEmpty(_JwtExpireDays))
                    _JwtExpireDays = Configuration["JwtExpireDays"];

                return _JwtExpireDays;
            }
        }

        private static string _JwtKey;

        public static string JwtKey
        {
            get
            {
                if (String.IsNullOrEmpty(_JwtKey))
                    _JwtKey = Configuration["JwtKey"];

                return _JwtKey;
            }
        }

        private static string _defaultConnectionString;

        public static string DefaultConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_defaultConnectionString))
                    _defaultConnectionString = Configuration["ConnectionStrings:DefaultConnection"];

                return _defaultConnectionString;
            }
        }

        private static IConfigurationRoot _configuration;

        private static IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json");

                    _configuration = builder.Build();
                }

                return _configuration;
            }
        }

		private static string _logConnectionString;

        public static string LogConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_logConnectionString))
                    _logConnectionString = Configuration["ConnectionStrings:LogConnectionString"];

                return _logConnectionString;
            }
        }
    }
}
