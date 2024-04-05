using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionCards_Collections_CollectionId",
                table: "CollectionCards");

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("8d7643eb-af08-41a6-88bb-d594e3670b50"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("120886bd-0f60-4cc8-9451-ce44ac17b5d1"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "CollectionCards",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CollectionId",
                table: "CollectionCards",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("82750c5b-70e9-41f9-a7ad-dd294537cb55"), new Guid("18a0d407-1254-4632-9d3e-88abe5388c27") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("18a0d407-1254-4632-9d3e-88abe5388c27"), 1, "admin@unlimited.co.za" });

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionCards_Collections_CollectionId",
                table: "CollectionCards",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionCards_Collections_CollectionId",
                table: "CollectionCards");

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("82750c5b-70e9-41f9-a7ad-dd294537cb55"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("18a0d407-1254-4632-9d3e-88abe5388c27"));

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "CollectionCards",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CollectionId",
                table: "CollectionCards",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("8d7643eb-af08-41a6-88bb-d594e3670b50"), new Guid("120886bd-0f60-4cc8-9451-ce44ac17b5d1") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("120886bd-0f60-4cc8-9451-ce44ac17b5d1"), 1, "admin@unlimited.co.za" });

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionCards_Collections_CollectionId",
                table: "CollectionCards",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");
        }
    }
}
