using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JBATechTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RainData",
                columns: table => new
                {
                    RainDataID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    XRef = table.Column<int>(nullable: false),
                    YRef = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RainData", x => x.RainDataID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RainData");
        }
    }
}
