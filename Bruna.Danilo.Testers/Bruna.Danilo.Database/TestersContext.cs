using System;
using Bruna.Danilo.Testers.Database.Entities;
using Bruna.Danilo.Testers.Settings;
using Microsoft.EntityFrameworkCore;

namespace Bruna.Danilo.Testers.Database
{
	public class TestersContext: DbContext
    {
		public TestersContext(DbContextOptions<TestersContext> options)
          : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(AppSettings.DefaultConnectionString)
                          .EnableSensitiveDataLogging();
        }

		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			builder.Entity<User>()
                        .HasIndex(b => b.FullName);
			builder.Entity<User>()
                .HasIndex(b => b.Sex);
			builder.Entity<User>()
            .HasIndex(b => b.City);
			builder.Entity<User>()
            .HasIndex(b => b.Estado);
			builder.Entity<User>()
            .HasIndex(b => b.AcceptTerms);
			builder.Ignore<Role>();
			builder.Ignore<UserRole>();
        }

		public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
    }
}
