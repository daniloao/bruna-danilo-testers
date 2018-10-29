using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class LocalidadeCampanha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampanhaEstadoCidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CampanhaEstado",
                table: "CampanhaEstado");

            migrationBuilder.DropIndex(
                name: "IX_CampanhaEstado_CampanhaId",
                table: "CampanhaEstado");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CampanhaEstado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CampanhaEstado",
                table: "CampanhaEstado",
                columns: new[] { "CampanhaId", "EstadoId" });

            migrationBuilder.CreateTable(
                name: "CampanhaCidade",
                columns: table => new
                {
                    CampanhaId = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaCidade", x => new { x.CampanhaId, x.CidadeId });
                    table.ForeignKey(
                        name: "FK_CampanhaCidade_Campanha_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampanhaCidade_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaCidade_CidadeId",
                table: "CampanhaCidade",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampanhaCidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CampanhaEstado",
                table: "CampanhaEstado");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CampanhaEstado",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CampanhaEstado",
                table: "CampanhaEstado",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CampanhaEstadoCidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CampanhaEstadoId = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaEstadoCidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampanhaEstadoCidade_CampanhaEstado_CampanhaEstadoId",
                        column: x => x.CampanhaEstadoId,
                        principalTable: "CampanhaEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampanhaEstadoCidade_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstado_CampanhaId",
                table: "CampanhaEstado",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstadoCidade_CampanhaEstadoId",
                table: "CampanhaEstadoCidade",
                column: "CampanhaEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstadoCidade_CidadeId",
                table: "CampanhaEstadoCidade",
                column: "CidadeId");
        }
    }
}
