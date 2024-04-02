using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UnlimitedDBv11 : Migration
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
                    Subtitle = table.Column<string>(type: "text", nullable: false, defaultValue: "None"),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Aspects = table.Column<int[]>(type: "integer[]", nullable: true),
                    Traits = table.Column<int[]>(type: "integer[]", nullable: false),
                    Arenas = table.Column<int[]>(type: "integer[]", nullable: false),
                    Cost = table.Column<string>(type: "text", nullable: false, defaultValue: "0"),
                    Power = table.Column<string>(type: "text", nullable: false, defaultValue: "0"),
                    HP = table.Column<string>(type: "text", nullable: false, defaultValue: "0"),
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CardSet = table.Column<int>(type: "integer", nullable: false),
                    CardNumber = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: true),
                    CardMake = table.Column<int>(type: "integer", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionCards_Cards_CardSet_CardNumber",
                        columns: x => new { x.CardSet, x.CardNumber },
                        principalTable: "Cards",
                        principalColumns: new[] { "Set", "Number" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionCards_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthId", "Email" },
                values: new object[] { new Guid("4409c495-2995-48f3-ac08-0a126bd07042"), 1, "admin@unlimited.co.za" });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionCards_CardSet_CardNumber",
                table: "CollectionCards",
                columns: new[] { "CardSet", "CardNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionCards_CollectionId",
                table: "CollectionCards",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_OwnerId",
                table: "Collections",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionCards");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
