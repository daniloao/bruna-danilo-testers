using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class Renamecnpj2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Cliente",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Cliente",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
