using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4409c495-2995-48f3-ac08-0a126bd07042"));

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "CollectionCards",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarketPrice",
                table: "Cards",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VariantType",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("ae707815-21bf-4b91-921e-28f28a343844"), 1, "admin@unlimited.co.za" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae707815-21bf-4b91-921e-28f28a343844"));

            migrationBuilder.DropColumn(
                name: "MarketPrice",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "VariantType",
                table: "Cards");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "CollectionCards",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("4409c495-2995-48f3-ac08-0a126bd07042"), 1, "admin@unlimited.co.za" });
        }
    }
}
