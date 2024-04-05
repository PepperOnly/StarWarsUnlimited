using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Users_OwnerId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_OwnerId",
                table: "Collections");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fd4dc3f8-764e-4753-8d3b-fa6bca2ac37d"));

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Collections",
                newName: "UserId");

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("14b101ed-65b7-4ae6-84dc-dd8b29e7bdc3"), new Guid("e93f5e82-8d7d-427d-a500-c76a933f7991") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("e93f5e82-8d7d-427d-a500-c76a933f7991"), 1, "admin@unlimited.co.za" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("14b101ed-65b7-4ae6-84dc-dd8b29e7bdc3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e93f5e82-8d7d-427d-a500-c76a933f7991"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Collections",
                newName: "OwnerId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("fd4dc3f8-764e-4753-8d3b-fa6bca2ac37d"), 1, "admin@unlimited.co.za" });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_OwnerId",
                table: "Collections",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Users_OwnerId",
                table: "Collections",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
