using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ensek.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "MeterReadings",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ReadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReadings", x => new { x.AccountId, x.ReadDate });
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1234, "Freya", "Test" },
                    { 4534, "JOSH", "TEST" },
                    { 2356, "Craig", "Test" },
                    { 2355, "Arthur", "Test" },
                    { 2353, "Tony", "Test" },
                    { 2352, "Greg", "Test" },
                    { 2351, "Gladys", "Test" },
                    { 2350, "Colin", "Test" },
                    { 2349, "Simon", "Test" },
                    { 2348, "Tammy", "Test" },
                    { 2347, "Tara", "Test" },
                    { 2346, "Ollie", "Test" },
                    { 6776, "Laura", "Test" },
                    { 2345, "Jerry", "Test" },
                    { 2233, "Barry", "Test" },
                    { 1248, "Pam", "Test" },
                    { 1247, "Jim", "Test" },
                    { 1246, "Jo", "Test" },
                    { 1245, "Neville", "Test" },
                    { 1244, "Tony", "Test" },
                    { 1243, "Graham", "Test" },
                    { 1242, "Tim", "Test" },
                    { 1241, "Lara", "Test" },
                    { 1240, "Archie", "Test" },
                    { 1239, "Noddy", "Test" },
                    { 2344, "Tommy", "Test" },
                    { 8766, "Sally", "Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "MeterReadings");
        }
    }
}
