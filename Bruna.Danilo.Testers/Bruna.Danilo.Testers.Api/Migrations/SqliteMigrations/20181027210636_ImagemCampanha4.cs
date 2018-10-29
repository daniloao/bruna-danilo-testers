using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class ImagemCampanha4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
		{
            migrationBuilder.DropIndex(
                name: "IX_CampanhaEstado_CampanhaEstadoId",
                table: "CampanhaEstado");

            migrationBuilder.DropIndex(
                name: "IX_CampanhaEstado_CidadeId",
                table: "CampanhaEstado");

            migrationBuilder.DropColumn(
                name: "CampanhaEstadoId",
                table: "CampanhaEstado");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "CampanhaEstado");

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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstadoCidade_CampanhaEstadoId",
                table: "CampanhaEstadoCidade",
                column: "CampanhaEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstadoCidade_CidadeId",
                table: "CampanhaEstadoCidade",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampanhaEstadoCidade");

            migrationBuilder.AddColumn<int>(
                name: "CampanhaEstadoId",
                table: "CampanhaEstado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "CampanhaEstado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstado_CampanhaEstadoId",
                table: "CampanhaEstado",
                column: "CampanhaEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstado_CidadeId",
                table: "CampanhaEstado",
                column: "CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampanhaEstado_CampanhaEstado_CampanhaEstadoId",
                table: "CampanhaEstado",
                column: "CampanhaEstadoId",
                principalTable: "CampanhaEstado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CampanhaEstado_Cidade_CidadeId",
                table: "CampanhaEstado",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
