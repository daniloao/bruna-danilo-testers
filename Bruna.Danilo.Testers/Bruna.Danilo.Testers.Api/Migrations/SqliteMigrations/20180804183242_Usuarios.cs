using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bruna.Danilo.Testers.Api.Migrations.SqliteMigrations
{
    public partial class Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddColumn<string>("FullName",
									   "AspNetUsers",
									   nullable: false);
			
			migrationBuilder.AddColumn<string>("Sex",
                                       "AspNetUsers",
                                       nullable: false,
			                           maxLength: 1);
			
			migrationBuilder.AddColumn<string>("City",
                                   "AspNetUsers",
                                   nullable: false);
			
			migrationBuilder.AddColumn<string>("Estado",
                                   "AspNetUsers",
                                   nullable: false,
			                           maxLength: 2);

			migrationBuilder.AddColumn<bool>("AcceptTerms",
                           "AspNetUsers",
                           nullable: false);
		
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
