using System;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Bruna.Danilo.Testers.Api.Infraestructure
{
    public static class AppSettings
    {
		private static string _defaultConnectionString;

		public static string DefaultConnectionString
		{
			get{
				if(String.IsNullOrEmpty(_defaultConnectionString))
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
    }
}
