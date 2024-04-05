using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("df99c1ef-711e-497a-bf08-a08302de62af"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e470e39a-9b7b-4a6e-bd70-c21612f20edc"));

            migrationBuilder.DropColumn(
                name: "CardMake",
                table: "CollectionCards");

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("8d7643eb-af08-41a6-88bb-d594e3670b50"), new Guid("120886bd-0f60-4cc8-9451-ce44ac17b5d1") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("120886bd-0f60-4cc8-9451-ce44ac17b5d1"), 1, "admin@unlimited.co.za" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("8d7643eb-af08-41a6-88bb-d594e3670b50"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("120886bd-0f60-4cc8-9451-ce44ac17b5d1"));

            migrationBuilder.AddColumn<int>(
                name: "CardMake",
                table: "CollectionCards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("df99c1ef-711e-497a-bf08-a08302de62af"), new Guid("e470e39a-9b7b-4a6e-bd70-c21612f20edc") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("e470e39a-9b7b-4a6e-bd70-c21612f20edc"), 1, "admin@unlimited.co.za" });
        }
    }
}
