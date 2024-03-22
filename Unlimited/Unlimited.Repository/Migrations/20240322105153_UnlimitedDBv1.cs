using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Set = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Subtitle = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Aspects = table.Column<int[]>(type: "integer[]", nullable: false),
                    Traits = table.Column<int[]>(type: "integer[]", nullable: false),
                    Arenas = table.Column<int[]>(type: "integer[]", nullable: false),
                    Cost = table.Column<string>(type: "text", nullable: false),
                    Power = table.Column<string>(type: "text", nullable: false),
                    HP = table.Column<string>(type: "text", nullable: false),
                    FrontText = table.Column<string>(type: "text", nullable: true),
                    EpicAction = table.Column<string>(type: "text", nullable: true),
                    DoubleSided = table.Column<bool>(type: "boolean", nullable: false),
                    BackText = table.Column<string>(type: "text", nullable: true),
                    Rarity = table.Column<string>(type: "text", nullable: false),
                    Unique = table.Column<bool>(type: "boolean", nullable: false),
                    Keywords = table.Column<int[]>(type: "integer[]", nullable: true),
                    Artist = table.Column<string>(type: "text", nullable: false),
                    FrontArt = table.Column<string>(type: "text", nullable: false),
                    BackArt = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => new { x.Set, x.Number });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
