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
            migrationBuilder.AlterColumn<string>(
                name: "Subtitle",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "None",
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subtitle",
                table: "Cards",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "None");
        }
    }
}
