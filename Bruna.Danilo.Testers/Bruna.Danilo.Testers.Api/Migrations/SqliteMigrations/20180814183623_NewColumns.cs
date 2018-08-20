using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class NewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contado",
                table: "Cliente",
                newName: "Contato");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_Contado",
                table: "Cliente",
                newName: "IX_Cliente_Contato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contato",
                table: "Cliente",
                newName: "Contado");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_Contato",
                table: "Cliente",
                newName: "IX_Cliente_Contado");
        }
    }
}
