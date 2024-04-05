using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("6fe2cde9-3b65-478d-996c-fd675d70b142"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f99e0f8d-53b4-4010-b2e1-9e3d1461645f"));

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("df99c1ef-711e-497a-bf08-a08302de62af"), new Guid("e470e39a-9b7b-4a6e-bd70-c21612f20edc") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("e470e39a-9b7b-4a6e-bd70-c21612f20edc"), 1, "admin@unlimited.co.za" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("df99c1ef-711e-497a-bf08-a08302de62af"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e470e39a-9b7b-4a6e-bd70-c21612f20edc"));

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("6fe2cde9-3b65-478d-996c-fd675d70b142"), new Guid("f99e0f8d-53b4-4010-b2e1-9e3d1461645f") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("f99e0f8d-53b4-4010-b2e1-9e3d1461645f"), 1, "admin@unlimited.co.za" });
        }
    }
}
