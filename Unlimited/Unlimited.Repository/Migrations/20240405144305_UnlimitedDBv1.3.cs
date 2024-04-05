using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae707815-21bf-4b91-921e-28f28a343844"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Currency",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<decimal>(
                name: "MarketPrice",
                table: "Cards",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("fd4dc3f8-764e-4753-8d3b-fa6bca2ac37d"), 1, "admin@unlimited.co.za" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fd4dc3f8-764e-4753-8d3b-fa6bca2ac37d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Currency",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MarketPrice",
                table: "Cards",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("ae707815-21bf-4b91-921e-28f28a343844"), 1, "admin@unlimited.co.za" });
        }
    }
}
