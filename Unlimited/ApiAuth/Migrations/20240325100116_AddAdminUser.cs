using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAuth.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserAuthorization",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username", "isActive" },
                values: new object[] { 1, "Admin", "Account", "!@#$%A1", "sa", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAuthorization",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
