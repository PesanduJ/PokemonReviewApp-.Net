using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pokemons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reviewers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviewers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.id);
                    table.ForeignKey(
                        name: "FK_owners_countries_countryid",
                        column: x => x.countryid,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pokemonCategories",
                columns: table => new
                {
                    pokemonId = table.Column<int>(type: "int", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemonCategories", x => new { x.pokemonId, x.categoryId });
                    table.ForeignKey(
                        name: "FK_pokemonCategories_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pokemonCategories_pokemons_pokemonId",
                        column: x => x.pokemonId,
                        principalTable: "pokemons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reviewerid = table.Column<int>(type: "int", nullable: false),
                    pokemonid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_reviews_pokemons_pokemonid",
                        column: x => x.pokemonid,
                        principalTable: "pokemons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_reviewers_reviewerid",
                        column: x => x.reviewerid,
                        principalTable: "reviewers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pokemonOwners",
                columns: table => new
                {
                    pokemonId = table.Column<int>(type: "int", nullable: false),
                    ownerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemonOwners", x => new { x.pokemonId, x.ownerId });
                    table.ForeignKey(
                        name: "FK_pokemonOwners_owners_ownerId",
                        column: x => x.ownerId,
                        principalTable: "owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pokemonOwners_pokemons_pokemonId",
                        column: x => x.pokemonId,
                        principalTable: "pokemons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_owners_countryid",
                table: "owners",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_pokemonCategories_categoryId",
                table: "pokemonCategories",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_pokemonOwners_ownerId",
                table: "pokemonOwners",
                column: "ownerId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_pokemonid",
                table: "reviews",
                column: "pokemonid");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_reviewerid",
                table: "reviews",
                column: "reviewerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pokemonCategories");

            migrationBuilder.DropTable(
                name: "pokemonOwners");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "pokemons");

            migrationBuilder.DropTable(
                name: "reviewers");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
