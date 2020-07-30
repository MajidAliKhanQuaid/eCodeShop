using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopCore.Infrastructure.Migrations
{
    public partial class AddedRefreshTokenColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedOnUtc", "UpdatedOnUtc" },
                values: new object[] { new DateTime(2020, 7, 28, 18, 48, 31, 434, DateTimeKind.Utc).AddTicks(7381), new DateTime(2020, 7, 28, 18, 48, 31, 434, DateTimeKind.Utc).AddTicks(7717) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedOnUtc", "UpdatedOnUtc" },
                values: new object[] { new DateTime(2020, 7, 26, 10, 1, 24, 903, DateTimeKind.Utc).AddTicks(692), new DateTime(2020, 7, 26, 10, 1, 24, 903, DateTimeKind.Utc).AddTicks(2377) });
        }
    }
}
