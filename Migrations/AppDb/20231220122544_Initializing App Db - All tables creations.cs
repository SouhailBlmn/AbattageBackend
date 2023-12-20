using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Abattage_BackEnd.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class InitializingAppDbAlltablescreations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Designstion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Libelle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticlesBetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Designation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesBetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Plafond = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stabulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    Capacite = table.Column<int>(type: "integer", nullable: false),
                    Utilisee = table.Column<int>(type: "integer", nullable: false),
                    Libre = table.Column<int>(type: "integer", nullable: false),
                    EstPlein = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stabulations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAbattages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAbattages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesBetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Designation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesBetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chevillards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Plafond = table.Column<float>(type: "real", nullable: true),
                    Cin = table.Column<string>(type: "text", nullable: false),
                    CinImg = table.Column<string>(type: "text", nullable: false),
                    AcheteurIntestinalId = table.Column<int>(type: "integer", nullable: false),
                    AcheteurIntestinId = table.Column<int>(type: "integer", nullable: false),
                    AcheteurPeauId = table.Column<int>(type: "integer", nullable: false),
                    AcheteurTeteId = table.Column<int>(type: "integer", nullable: false),
                    AcheteurAutreId = table.Column<int>(type: "integer", nullable: false),
                    Num_carte = table.Column<string>(type: "text", nullable: false),
                    Infos = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false),
                    Actif = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chevillards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chevillards_Clients_AcheteurAutreId",
                        column: x => x.AcheteurAutreId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chevillards_Clients_AcheteurIntestinId",
                        column: x => x.AcheteurIntestinId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chevillards_Clients_AcheteurPeauId",
                        column: x => x.AcheteurPeauId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chevillards_Clients_AcheteurTeteId",
                        column: x => x.AcheteurTeteId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticlesTypseBetails",
                columns: table => new
                {
                    ArticlesId = table.Column<int>(type: "integer", nullable: false),
                    TypesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesTypseBetails", x => new { x.ArticlesId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_ArticlesTypseBetails_ArticlesBetails_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "ArticlesBetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticlesTypseBetails_TypesBetails_TypesId",
                        column: x => x.TypesId,
                        principalTable: "TypesBetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChevillardId = table.Column<int>(type: "integer", nullable: false),
                    Tripier = table.Column<int>(type: "integer", nullable: true),
                    Nombre = table.Column<int>(type: "integer", nullable: false),
                    StabulationVachesId = table.Column<int>(type: "integer", nullable: false),
                    StabulationMoutonsId = table.Column<int>(type: "integer", nullable: false),
                    StabulationBovinsId = table.Column<int>(type: "integer", nullable: false),
                    NbBovins = table.Column<int>(type: "integer", nullable: false),
                    NbVaches = table.Column<int>(type: "integer", nullable: false),
                    NbMoutons = table.Column<int>(type: "integer", nullable: false),
                    AcheteurIntestinId = table.Column<int>(type: "integer", nullable: false),
                    AcheteurPeauId = table.Column<int>(type: "integer", nullable: false),
                    AcheteurTeteId = table.Column<int>(type: "integer", nullable: false),
                    AcheteurAutreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptions_Chevillards_ChevillardId",
                        column: x => x.ChevillardId,
                        principalTable: "Chevillards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptions_Clients_AcheteurAutreId",
                        column: x => x.AcheteurAutreId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptions_Clients_AcheteurIntestinId",
                        column: x => x.AcheteurIntestinId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptions_Clients_AcheteurPeauId",
                        column: x => x.AcheteurPeauId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptions_Clients_AcheteurTeteId",
                        column: x => x.AcheteurTeteId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptions_Stabulations_StabulationBovinsId",
                        column: x => x.StabulationBovinsId,
                        principalTable: "Stabulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptions_Stabulations_StabulationMoutonsId",
                        column: x => x.StabulationMoutonsId,
                        principalTable: "Stabulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptions_Stabulations_StabulationVachesId",
                        column: x => x.StabulationVachesId,
                        principalTable: "Stabulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carcasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeBarre = table.Column<string>(type: "text", nullable: false),
                    OrdreSacrifice = table.Column<int>(type: "integer", nullable: true),
                    TypeBetailId = table.Column<int>(type: "integer", nullable: false),
                    StabulationId = table.Column<int>(type: "integer", nullable: false),
                    DateGeneration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TypeAbattageId = table.Column<int>(type: "integer", nullable: false),
                    ReceptionId = table.Column<int>(type: "integer", nullable: false),
                    AnimalStatusId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carcasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carcasses_AnimalStatuses_AnimalStatusId",
                        column: x => x.AnimalStatusId,
                        principalTable: "AnimalStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carcasses_Receptions_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Receptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carcasses_Stabulations_StabulationId",
                        column: x => x.StabulationId,
                        principalTable: "Stabulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carcasses_TypeAbattages_TypeAbattageId",
                        column: x => x.TypeAbattageId,
                        principalTable: "TypeAbattages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carcasses_TypesBetails_TypeBetailId",
                        column: x => x.TypeBetailId,
                        principalTable: "TypesBetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumLigne = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TypeOrdre = table.Column<string>(type: "text", nullable: true),
                    ReceptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planifications_Receptions_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "Receptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesTypseBetails_TypesId",
                table: "ArticlesTypseBetails",
                column: "TypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Carcasses_AnimalStatusId",
                table: "Carcasses",
                column: "AnimalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Carcasses_ReceptionId",
                table: "Carcasses",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Carcasses_StabulationId",
                table: "Carcasses",
                column: "StabulationId");

            migrationBuilder.CreateIndex(
                name: "IX_Carcasses_TypeAbattageId",
                table: "Carcasses",
                column: "TypeAbattageId");

            migrationBuilder.CreateIndex(
                name: "IX_Carcasses_TypeBetailId",
                table: "Carcasses",
                column: "TypeBetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Chevillards_AcheteurAutreId",
                table: "Chevillards",
                column: "AcheteurAutreId");

            migrationBuilder.CreateIndex(
                name: "IX_Chevillards_AcheteurIntestinId",
                table: "Chevillards",
                column: "AcheteurIntestinId");

            migrationBuilder.CreateIndex(
                name: "IX_Chevillards_AcheteurPeauId",
                table: "Chevillards",
                column: "AcheteurPeauId");

            migrationBuilder.CreateIndex(
                name: "IX_Chevillards_AcheteurTeteId",
                table: "Chevillards",
                column: "AcheteurTeteId");

            migrationBuilder.CreateIndex(
                name: "IX_Planifications_ReceptionId",
                table: "Planifications",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_AcheteurAutreId",
                table: "Receptions",
                column: "AcheteurAutreId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_AcheteurIntestinId",
                table: "Receptions",
                column: "AcheteurIntestinId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_AcheteurPeauId",
                table: "Receptions",
                column: "AcheteurPeauId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_AcheteurTeteId",
                table: "Receptions",
                column: "AcheteurTeteId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_ChevillardId",
                table: "Receptions",
                column: "ChevillardId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_StabulationBovinsId",
                table: "Receptions",
                column: "StabulationBovinsId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_StabulationMoutonsId",
                table: "Receptions",
                column: "StabulationMoutonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_StabulationVachesId",
                table: "Receptions",
                column: "StabulationVachesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleStatuses");

            migrationBuilder.DropTable(
                name: "ArticlesTypseBetails");

            migrationBuilder.DropTable(
                name: "Carcasses");

            migrationBuilder.DropTable(
                name: "Planifications");

            migrationBuilder.DropTable(
                name: "ArticlesBetails");

            migrationBuilder.DropTable(
                name: "AnimalStatuses");

            migrationBuilder.DropTable(
                name: "TypeAbattages");

            migrationBuilder.DropTable(
                name: "TypesBetails");

            migrationBuilder.DropTable(
                name: "Receptions");

            migrationBuilder.DropTable(
                name: "Chevillards");

            migrationBuilder.DropTable(
                name: "Stabulations");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
