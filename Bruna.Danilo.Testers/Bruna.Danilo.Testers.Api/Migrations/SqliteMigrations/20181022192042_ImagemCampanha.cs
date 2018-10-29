using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class ImagemCampanha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Campanha");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Campanha");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Imagem",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CampanhaImagem",
                columns: table => new
                {
                    CampanhaId = table.Column<int>(nullable: false),
                    ImagemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaImagem", x => new { x.CampanhaId, x.ImagemId });
                    table.ForeignKey(
                        name: "FK_CampanhaImagem_Campanha_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampanhaImagem_Imagem_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaImagem_ImagemId",
                table: "CampanhaImagem",
                column: "ImagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampanhaImagem");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Imagem");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Campanha",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Campanha",
                nullable: true);
        }
    }
}
