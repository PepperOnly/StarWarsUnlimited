using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("82750c5b-70e9-41f9-a7ad-dd294537cb55"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("18a0d407-1254-4632-9d3e-88abe5388c27"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("72cbe03c-b7e6-4425-b015-d97d72cc549b"), new Guid("284f67b9-2512-41b5-9827-d0d06f46bf1f") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("284f67b9-2512-41b5-9827-d0d06f46bf1f"), 1, "admin@unlimited.co.za" });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionCards_CardId",
                table: "CollectionCards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionCards_Cards_CardId",
                table: "CollectionCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionCards_Cards_CardId",
                table: "CollectionCards");

            migrationBuilder.DropIndex(
                name: "IX_CollectionCards_CardId",
                table: "CollectionCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "Id",
                keyValue: new Guid("72cbe03c-b7e6-4425-b015-d97d72cc549b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("284f67b9-2512-41b5-9827-d0d06f46bf1f"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                columns: new[] { "Set", "Number" });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("82750c5b-70e9-41f9-a7ad-dd294537cb55"), new Guid("18a0d407-1254-4632-9d3e-88abe5388c27") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("18a0d407-1254-4632-9d3e-88abe5388c27"), 1, "admin@unlimited.co.za" });
        }
    }
}
