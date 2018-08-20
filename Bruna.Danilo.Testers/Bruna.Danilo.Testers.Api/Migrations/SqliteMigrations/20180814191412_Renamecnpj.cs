using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class Renamecnpj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Cliente",
                newName: "Cnpj");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_CNPJ",
                table: "Cliente",
                newName: "IX_Cliente_Cnpj");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Cliente",
                newName: "CNPJ");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_Cnpj",
                table: "Cliente",
                newName: "IX_Cliente_CNPJ");
        }
    }
}
