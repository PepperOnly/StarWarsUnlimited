using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("72cbe03c-b7e6-4425-b015-d97d72cc549b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("284f67b9-2512-41b5-9827-d0d06f46bf1f"));

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("c94bd745-58f3-4e91-b787-1288252d0b17"), new Guid("b0ac4c00-af6e-4eb4-b89f-67e593e1d644") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("b0ac4c00-af6e-4eb4-b89f-67e593e1d644"), 1, "admin@unlimited.co.za" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("c94bd745-58f3-4e91-b787-1288252d0b17"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0ac4c00-af6e-4eb4-b89f-67e593e1d644"));

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("72cbe03c-b7e6-4425-b015-d97d72cc549b"), new Guid("284f67b9-2512-41b5-9827-d0d06f46bf1f") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("284f67b9-2512-41b5-9827-d0d06f46bf1f"), 1, "admin@unlimited.co.za" });
        }
    }
}
