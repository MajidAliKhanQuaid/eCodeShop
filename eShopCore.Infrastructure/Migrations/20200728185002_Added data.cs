using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopCore.Infrastructure.Migrations
{
    public partial class Addeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { -3, "Apply Granny Smith", "", "Apple", 12.44m },
                    { -2, "Mango From Multan", "", "Mango", 14.44m },
                    { -1, "Orange From Peshawar", "", "Orange", 155.44m }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedOnUtc", "UpdatedOnUtc" },
                values: new object[] { new DateTime(2020, 7, 28, 18, 50, 1, 670, DateTimeKind.Utc).AddTicks(6316), new DateTime(2020, 7, 28, 18, 50, 1, 670, DateTimeKind.Utc).AddTicks(7020) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedOnUtc", "UpdatedOnUtc" },
                values: new object[] { new DateTime(2020, 7, 28, 18, 48, 31, 434, DateTimeKind.Utc).AddTicks(7381), new DateTime(2020, 7, 28, 18, 48, 31, 434, DateTimeKind.Utc).AddTicks(7717) });
        }
    }
}
