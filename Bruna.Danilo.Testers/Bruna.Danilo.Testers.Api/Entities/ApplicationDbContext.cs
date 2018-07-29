using Bruna.Danilo.Testers.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bruna.Danilo.Testers.Api.Entities
{
	public class ApplicationDbContext : IdentityDbContext
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(AppSettings.DefaultConnectionString);
		}
    }
}
