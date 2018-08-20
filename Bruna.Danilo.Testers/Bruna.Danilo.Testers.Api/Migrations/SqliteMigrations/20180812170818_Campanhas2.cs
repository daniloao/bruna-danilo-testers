using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class Campanhas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TipoCampanha",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cliente",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Campanha",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Anunciante",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TipoCampanha");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Anunciante");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Campanha",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }
    }
}
