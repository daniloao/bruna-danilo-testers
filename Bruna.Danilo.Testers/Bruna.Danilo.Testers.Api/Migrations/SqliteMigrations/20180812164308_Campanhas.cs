using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class Campanhas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anunciante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anunciante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anunciante_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anunciante_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

           // migrationBuilder.CreateTable(
           //     name: "AspNetUserRoles",
           //     columns: table => new
           //     {
           //         UserId = table.Column<string>(maxLength: 450, nullable: false),
           //         RoleId = table.Column<string>(maxLength: 450, nullable: false)
           //     },
           //     constraints: table =>
           //     {
			//         table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
			//         table.UniqueConstraint("AK_AspNetUserRoles_RoleId_UserId", x => new { x.RoleId, x.UserId });
			//         table.ForeignKey(
			//             name: "FK_AspNetUserRoles_AspNetUsers_UserId",
			//             column: x => x.UserId,
			//            principalTable: "AspNetUsers",
			//             principalColumn: "Id",
			//             onDelete: ReferentialAction.Cascade);
			//     });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    RazaoSocial = table.Column<string>(nullable: false),
                    NomeFantasia = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    Skype = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Contado = table.Column<string>(nullable: false),
                    CidadeId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoCampanha",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<string>(maxLength: 450, nullable: true),
                    UpdatedById = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCampanha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoCampanha_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCampanha_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campanha",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Chave = table.Column<string>(maxLength: 450, nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    TipoCampanhaId = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: true),
                    EstadoId = table.Column<int>(nullable: true),
                    Logo = table.Column<byte[]>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LinkTrackeado = table.Column<string>(nullable: false),
                    Cupom = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    AnuncianteId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(maxLength: 450, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campanha_Anunciante_AnuncianteId",
                        column: x => x.AnuncianteId,
                        principalTable: "Anunciante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campanha_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campanha_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campanha_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campanha_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campanha_TipoCampanha_TipoCampanhaId",
                        column: x => x.TipoCampanhaId,
                        principalTable: "TipoCampanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campanha_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anunciante_CreatedById",
                table: "Anunciante",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Anunciante_Nome",
                table: "Anunciante",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Anunciante_UpdatedById",
                table: "Anunciante",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_AnuncianteId",
                table: "Campanha",
                column: "AnuncianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_Chave",
                table: "Campanha",
                column: "Chave");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_CidadeId",
                table: "Campanha",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_ClienteId",
                table: "Campanha",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_CreatedById",
                table: "Campanha",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_Cupom",
                table: "Campanha",
                column: "Cupom");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_DataFim",
                table: "Campanha",
                column: "DataFim");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_DataInicio",
                table: "Campanha",
                column: "DataInicio");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_EstadoId",
                table: "Campanha",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_IsActive",
                table: "Campanha",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_LinkTrackeado",
                table: "Campanha",
                column: "LinkTrackeado");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_TipoCampanhaId",
                table: "Campanha",
                column: "TipoCampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_Titulo",
                table: "Campanha",
                column: "Titulo");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_UpdatedById",
                table: "Campanha",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_DataInicio_DataFim",
                table: "Campanha",
                columns: new[] { "DataInicio", "DataFim" });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CNPJ",
                table: "Cliente",
                column: "CNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CidadeId",
                table: "Cliente",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Contado",
                table: "Cliente",
                column: "Contado");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CreatedById",
                table: "Cliente",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Email",
                table: "Cliente",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EstadoId",
                table: "Cliente",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_NomeFantasia",
                table: "Cliente",
                column: "NomeFantasia");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_RazaoSocial",
                table: "Cliente",
                column: "RazaoSocial");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UpdatedById",
                table: "Cliente",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCampanha_CreatedById",
                table: "TipoCampanha",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCampanha_Descricao",
                table: "TipoCampanha",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCampanha_UpdatedById",
                table: "TipoCampanha",
                column: "UpdatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			//  migrationBuilder.DropTable(
			//     name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "Campanha");

            migrationBuilder.DropTable(
                name: "Anunciante");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoCampanha");
        }
    }
}
