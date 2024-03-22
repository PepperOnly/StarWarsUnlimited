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
            migrationBuilder.AlterColumn<int[]>(
                name: "Aspects",
                table: "Cards",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(int[]),
                oldType: "integer[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int[]>(
                name: "Aspects",
                table: "Cards",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0],
                oldClrType: typeof(int[]),
                oldType: "integer[]",
                oldNullable: true);
        }
    }
}
