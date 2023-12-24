using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Abattage_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Depotstableadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepotId",
                table: "ArticleParAnimals",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Depots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: true),
                    Adresse = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depots", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleParAnimals_DepotId",
                table: "ArticleParAnimals",
                column: "DepotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleParAnimals_Depots_DepotId",
                table: "ArticleParAnimals",
                column: "DepotId",
                principalTable: "Depots",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleParAnimals_Depots_DepotId",
                table: "ArticleParAnimals");

            migrationBuilder.DropTable(
                name: "Depots");

            migrationBuilder.DropIndex(
                name: "IX_ArticleParAnimals_DepotId",
                table: "ArticleParAnimals");

            migrationBuilder.DropColumn(
                name: "DepotId",
                table: "ArticleParAnimals");
        }
    }
}
