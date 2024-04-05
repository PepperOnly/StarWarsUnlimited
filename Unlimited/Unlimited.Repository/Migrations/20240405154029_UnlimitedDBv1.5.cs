using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionCards_Cards_CardSet_CardNumber",
                table: "CollectionCards");

            migrationBuilder.DropIndex(
                name: "IX_CollectionCards_CardSet_CardNumber",
                table: "CollectionCards");

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("14b101ed-65b7-4ae6-84dc-dd8b29e7bdc3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e93f5e82-8d7d-427d-a500-c76a933f7991"));

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "CollectionCards");

            migrationBuilder.DropColumn(
                name: "CardSet",
                table: "CollectionCards");

            migrationBuilder.AddColumn<Guid>(
                name: "CardId",
                table: "CollectionCards",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("6fe2cde9-3b65-478d-996c-fd675d70b142"), new Guid("f99e0f8d-53b4-4010-b2e1-9e3d1461645f") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("f99e0f8d-53b4-4010-b2e1-9e3d1461645f"), 1, "admin@unlimited.co.za" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("6fe2cde9-3b65-478d-996c-fd675d70b142"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f99e0f8d-53b4-4010-b2e1-9e3d1461645f"));

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "CollectionCards");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "CollectionCards",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CardSet",
                table: "CollectionCards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("14b101ed-65b7-4ae6-84dc-dd8b29e7bdc3"), new Guid("e93f5e82-8d7d-427d-a500-c76a933f7991") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("e93f5e82-8d7d-427d-a500-c76a933f7991"), 1, "admin@unlimited.co.za" });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionCards_CardSet_CardNumber",
                table: "CollectionCards",
                columns: new[] { "CardSet", "CardNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionCards_Cards_CardSet_CardNumber",
                table: "CollectionCards",
                columns: new[] { "CardSet", "CardNumber" },
                principalTable: "Cards",
                principalColumns: new[] { "Set", "Number" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
