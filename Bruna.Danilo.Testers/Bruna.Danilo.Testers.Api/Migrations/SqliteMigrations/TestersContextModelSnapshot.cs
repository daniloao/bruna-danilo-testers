﻿// <auto-generated />
using System;
using Bruna.Danilo.Testers.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    [DbContext(typeof(TestersContext))]
    partial class TestersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.Anunciante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById")
                        .HasMaxLength(450);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descricao");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Observacao");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("UpdatedById")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("Nome");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Anunciante");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.Campanha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnuncianteId");

                    b.Property<string>("Chave")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<int?>("CidadeId");

                    b.Property<int>("ClienteId");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(450);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Cupom");

                    b.Property<DateTime?>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<int?>("EstadoId");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("LinkTrackeado")
                        .IsRequired();

                    b.Property<byte[]>("Logo");

                    b.Property<string>("LogoUrl");

                    b.Property<string>("Texto");

                    b.Property<int>("TipoCampanhaId");

                    b.Property<string>("Titulo")
                        .IsRequired();

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("UpdatedById")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("AnuncianteId");

                    b.HasIndex("Chave");

                    b.HasIndex("CidadeId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("Cupom");

                    b.HasIndex("DataFim");

                    b.HasIndex("DataInicio");

                    b.HasIndex("EstadoId");

                    b.HasIndex("IsActive");

                    b.HasIndex("LinkTrackeado");

                    b.HasIndex("TipoCampanhaId");

                    b.HasIndex("Titulo");

                    b.HasIndex("UpdatedById");

                    b.HasIndex("DataInicio", "DataFim");

                    b.ToTable("Campanha");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.Cidade", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("EstadoId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CidadeId");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Contato")
                        .IsRequired();

                    b.Property<string>("CreatedById")
                        .HasMaxLength(450);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Endereco")
                        .IsRequired();

                    b.Property<int>("EstadoId");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("NomeFantasia");

                    b.Property<string>("RazaoSocial")
                        .IsRequired();

                    b.Property<string>("Skype");

                    b.Property<string>("Telefone");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("UpdatedById")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("Cnpj");

                    b.HasIndex("Contato");

                    b.HasIndex("CreatedById");

                    b.HasIndex("Email");

                    b.HasIndex("EstadoId");

                    b.HasIndex("NomeFantasia");

                    b.HasIndex("RazaoSocial");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.Estado", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Nome");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("Sigla");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.HistoricoCidadesEstados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("TimeStamp");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("HistoricoCidadesEstados");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.TipoCampanha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedById")
                        .HasMaxLength(450);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("UpdatedById")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("Descricao");

                    b.HasIndex("UpdatedById");

                    b.ToTable("TipoCampanha");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(450);

                    b.Property<bool>("AcceptTerms")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int>("AccessFailedCount");

                    b.Property<int?>("CidadeId");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("EstadoId");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Sex")
                        .HasMaxLength(1);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AcceptTerms");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("FullName");

                    b.HasIndex("Sex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.Property<string>("RoleId")
                        .HasMaxLength(450);

                    b.HasKey("UserId", "RoleId");

                    b.HasAlternateKey("RoleId", "UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.Anunciante", b =>
                {
                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.Campanha", b =>
                {
                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.Anunciante", "Anunciante")
                        .WithMany()
                        .HasForeignKey("AnuncianteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.TipoCampanha", "TipoCampanha")
                        .WithMany()
                        .HasForeignKey("TipoCampanhaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.Cidade", b =>
                {
                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.Cliente", b =>
                {
                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.HistoricoCidadesEstados", b =>
                {
                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.TipoCampanha", b =>
                {
                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.User", b =>
                {
                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");
                });

            modelBuilder.Entity("Bruna.Danilo.Testers.Database.Entities.UserRole", b =>
                {
                    b.HasOne("Bruna.Danilo.Testers.Database.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
