using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopCore.Infrastructure.Migrations
{
    public partial class AddedContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOnUtc", "Email", "Password", "Phone", "UpdatedOnUtc", "UserName" },
                values: new object[] { -1, new DateTime(2020, 7, 26, 10, 1, 24, 903, DateTimeKind.Utc).AddTicks(692), "user@ds.com", "1234", "0092 123 123", new DateTime(2020, 7, 26, 10, 1, 24, 903, DateTimeKind.Utc).AddTicks(2377), "ds" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
