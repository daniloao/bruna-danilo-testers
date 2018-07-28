using System;
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
			optionsBuilder.UseSqlServer("Server=tcp:bruna-danilo.database.windows.net;Database=Testers;User ID=danilo@bruna-danilo;Password=Bd@111014;Trusted_Connection=False;Encrypt=True;")
			              .EnableSensitiveDataLogging();
        }

		public DbSet<Entities.Logs> Logs { get; set; }
		public DbSet<Entities.LogType> LogTypes { get; set; }
    }
}
