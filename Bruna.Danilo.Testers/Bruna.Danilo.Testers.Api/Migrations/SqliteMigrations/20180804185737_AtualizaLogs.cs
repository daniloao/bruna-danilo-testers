using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class AtualizaLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Logs_StandardRefId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_StandardRefId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "StandardRefId",
                table: "Logs");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ParentLogId",
                table: "Logs",
                column: "ParentLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Logs_ParentLogId",
                table: "Logs",
                column: "ParentLogId",
                principalTable: "Logs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Logs_ParentLogId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_ParentLogId",
                table: "Logs");

            migrationBuilder.AddColumn<int>(
                name: "StandardRefId",
                table: "Logs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_StandardRefId",
                table: "Logs",
                column: "StandardRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Logs_StandardRefId",
                table: "Logs",
                column: "StandardRefId",
                principalTable: "Logs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
