using System;
using Bruna.Danilo.Testers.Settings;
using Microsoft.EntityFrameworkCore;

namespace Bruna.Danilo.Testers.Logs
{
	public class LogsContext : DbContext
    {
		public LogsContext(DbContextOptions<LogsContext> options)
            : base(options)
        { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder.UseSqlServer(AppSettings.LogConnectionString)
			              .EnableSensitiveDataLogging();
        }

		public DbSet<Entities.Logs> Logs { get; set; }
		public DbSet<Entities.LogType> LogTypes { get; set; }
    }
}
