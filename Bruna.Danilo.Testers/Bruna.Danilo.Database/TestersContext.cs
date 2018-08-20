using System;
using Bruna.Danilo.Testers.Database.Entities;
using Bruna.Danilo.Testers.Settings;
using Microsoft.AspNetCore.Identity;
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
			       .HasIndex(b => b.AcceptTerms);
			builder.Ignore<Role>();
			builder.Ignore<UserRole>();
			builder.Entity<User>()
			       .Property(b => b.AcceptTerms)
                   .HasDefaultValue(false);
			builder.Entity<Estado>()
                   .Property(c => c.Id)
                   .ValueGeneratedNever();
			builder.Entity<Cidade>()
                   .Property(c => c.Id)
                   .ValueGeneratedNever();
			builder.Entity<Estado>()
                   .HasIndex(b => b.Sigla);
			builder.Entity<UserRole>()
			       .HasKey(p => new { p.UserId, p.RoleId });         
			builder.Entity<Campanha>()
                   .HasIndex(b => b.Chave);
			builder.Entity<Campanha>()
                   .HasIndex(b => b.Titulo);
			builder.Entity<Campanha>()
			       .HasIndex(b => b.DataInicio);
			builder.Entity<Campanha>()
                   .HasIndex(b => b.DataFim);
			builder.Entity<Campanha>()
			       .HasIndex(b => new { b.DataInicio, b.DataFim });
			builder.Entity<Campanha>()
                   .HasIndex(b => b.IsActive);
			builder.Entity<Campanha>()
				   .HasIndex(b => b.LinkTrackeado);
			builder.Entity<Campanha>()
			       .HasIndex(b => b.Cupom);
			builder.Entity<Anunciante>()
                   .HasIndex(b => b.Nome);
			builder.Entity<Cliente>()
                   .HasIndex(b => b.Cnpj);
			builder.Entity<Cliente>()
			       .HasIndex(b => b.RazaoSocial);
			builder.Entity<Cliente>()
                   .HasIndex(b => b.NomeFantasia);
			builder.Entity<Cliente>()
                   .HasIndex(b => b.Email);
			builder.Entity<Cliente>()
                   .HasIndex(b => b.Contato);
			builder.Entity<TipoCampanha>()
                   .HasIndex(b => b.Descricao);
			builder.Entity<Anunciante>()
                   .Property(b => b.IsActive)
                   .HasDefaultValue(true);
			builder.Entity<Campanha>()
                   .Property(b => b.IsActive)
                   .HasDefaultValue(true);
			builder.Entity<Cliente>()
                   .Property(b => b.IsActive)
                   .HasDefaultValue(true);
			builder.Entity<TipoCampanha>()
                   .Property(b => b.IsActive)
                   .HasDefaultValue(true);
        }

		public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Estado> Estados { get; set; }
		public DbSet<Cidade> Cidades { get; set; }
		public DbSet<HistoricoCidadesEstados> HistoricoCidadesEstados { get; set; }
		public DbSet<TipoCampanha> TiposCampanha { get; set; }
		public DbSet<Anunciante> Anunciantes { get; set; }
		public DbSet<Campanha> Campanhas { get; set; }
		public DbSet<Cliente> Clientes { get; set; }
    }
}
