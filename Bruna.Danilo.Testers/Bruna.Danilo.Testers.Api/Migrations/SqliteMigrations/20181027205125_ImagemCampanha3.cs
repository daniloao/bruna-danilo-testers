using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class ImagemCampanha3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanha_Cidade_CidadeId",
                table: "Campanha");

            migrationBuilder.DropForeignKey(
                name: "FK_Campanha_Estado_EstadoId",
                table: "Campanha");

            migrationBuilder.DropIndex(
                name: "IX_Campanha_CidadeId",
                table: "Campanha");

            migrationBuilder.DropIndex(
                name: "IX_Campanha_EstadoId",
                table: "Campanha");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Campanha");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Campanha");

            migrationBuilder.CreateTable(
                name: "CampanhaEstado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CampanhaEstadoId = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: false),
                    CampanhaId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaEstado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampanhaEstado_Campanha_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampanhaEstado_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstado_CampanhaId",
                table: "CampanhaEstado",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstado_EstadoId",
                table: "CampanhaEstado",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstado_CampanhaEstadoId",
                table: "CampanhaEstado",
                column: "CampanhaEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaEstado_CidadeId",
                table: "CampanhaEstado",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampanhaEstado");

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Campanha",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Campanha",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_CidadeId",
                table: "Campanha",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_EstadoId",
                table: "Campanha",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanha_Cidade_CidadeId",
                table: "Campanha",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campanha_Estado_EstadoId",
                table: "Campanha",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
