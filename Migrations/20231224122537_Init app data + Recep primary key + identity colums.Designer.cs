﻿// <auto-generated />
using System;
using Abattage_BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Abattage_BackEnd.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231224122537_Init app data + Recep primary key + identity colums")]
    partial class InitappdataRecepprimarykeyidentitycolums
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Abattage_BackEnd.AnimalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AnimalStatuses");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.ArticleBetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ArticlesBetails");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.ArticleParAnimal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<int?>("ArticleTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Code_barre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date_generee")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Designation")
                        .HasColumnType("text");

                    b.Property<int?>("Poid")
                        .HasColumnType("integer");

                    b.Property<int?>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("ArticleTypeId");

                    b.HasIndex("StatusId");

                    b.ToTable("ArticleParAnimals");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.ArticleStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ArticleStatuses");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.ArticleTypeBetail", b =>
                {
                    b.Property<int>("ArticleBetailId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeBetailId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Qte")
                        .HasColumnType("integer");

                    b.HasKey("ArticleBetailId", "TypeBetailId");

                    b.HasIndex("TypeBetailId");

                    b.ToTable("ArticlesTypesBetails", (string)null);
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.Carcasse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnimalStatusId")
                        .HasColumnType("integer");

                    b.Property<string>("CodeBarre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateGeneration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OrdreSacrifice")
                        .HasColumnType("integer");

                    b.Property<int>("ReceptionId")
                        .HasColumnType("integer");

                    b.Property<int>("StabulationId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeAbattageId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeBetailId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnimalStatusId");

                    b.HasIndex("ReceptionId");

                    b.HasIndex("StabulationId");

                    b.HasIndex("TypeAbattageId");

                    b.HasIndex("TypeBetailId");

                    b.ToTable("Carcasses");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.Chevillard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AcheteurAutreId")
                        .HasColumnType("integer");

                    b.Property<int>("AcheteurIntestinId")
                        .HasColumnType("integer");

                    b.Property<int>("AcheteurIntestniId")
                        .HasColumnType("integer");

                    b.Property<int>("AcheteurPeauId")
                        .HasColumnType("integer");

                    b.Property<int>("AcheteurTeteId")
                        .HasColumnType("integer");

                    b.Property<bool>("Actif")
                        .HasColumnType("boolean");

                    b.Property<string>("Cin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CinImg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Infos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Num_carte")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float?>("Plafond")
                        .HasColumnType("real");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AcheteurAutreId");

                    b.HasIndex("AcheteurIntestinId");

                    b.HasIndex("AcheteurPeauId");

                    b.HasIndex("AcheteurTeteId");

                    b.ToTable("Chevillards");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Plafond")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.Planification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("NumLigne")
                        .HasColumnType("integer");

                    b.Property<int>("ReceptionId")
                        .HasColumnType("integer");

                    b.Property<string>("TypeOrdre")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReceptionId");

                    b.ToTable("Planifications");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.Reception", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AcheteurAutreId")
                        .HasColumnType("integer");

                    b.Property<int>("AcheteurIntestinId")
                        .HasColumnType("integer");

                    b.Property<int>("AcheteurPeauId")
                        .HasColumnType("integer");

                    b.Property<int>("AcheteurTeteId")
                        .HasColumnType("integer");

                    b.Property<int>("ChevillardId")
                        .HasColumnType("integer");

                    b.Property<int>("NbBovins")
                        .HasColumnType("integer");

                    b.Property<int>("NbMoutons")
                        .HasColumnType("integer");

                    b.Property<int>("NbVaches")
                        .HasColumnType("integer");

                    b.Property<int>("Nombre")
                        .HasColumnType("integer");

                    b.Property<int>("StabulationBovinsId")
                        .HasColumnType("integer");

                    b.Property<int>("StabulationMoutonsId")
                        .HasColumnType("integer");

                    b.Property<int>("StabulationVachesId")
                        .HasColumnType("integer");

                    b.Property<int?>("Tripier")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AcheteurAutreId");

                    b.HasIndex("AcheteurIntestinId");

                    b.HasIndex("AcheteurPeauId");

                    b.HasIndex("AcheteurTeteId");

                    b.HasIndex("ChevillardId");

                    b.HasIndex("StabulationBovinsId");

                    b.HasIndex("StabulationMoutonsId");

                    b.HasIndex("StabulationVachesId");

                    b.ToTable("Receptions");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.Stabulation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacite")
                        .HasColumnType("integer");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EstPlein")
                        .HasColumnType("boolean");

                    b.Property<int>("Libre")
                        .HasColumnType("integer");

                    b.Property<int>("Utilisee")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Stabulations");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.TypeAbattage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float?>("Prix")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("TypeAbattages");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.TypeBetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TypesBetails");
                });

            modelBuilder.Entity("ArticleBetailTypeBetail", b =>
                {
                    b.Property<int>("ArticlesId")
                        .HasColumnType("integer");

                    b.Property<int>("TypesId")
                        .HasColumnType("integer");

                    b.HasKey("ArticlesId", "TypesId");

                    b.HasIndex("TypesId");

                    b.ToTable("ArticleBetailTypeBetail");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.ArticleParAnimal", b =>
                {
                    b.HasOne("Abattage_BackEnd.Models.Carcasse", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId");

                    b.HasOne("Abattage_BackEnd.Models.ArticleBetail", "ArticleType")
                        .WithMany()
                        .HasForeignKey("ArticleTypeId");

                    b.HasOne("Abattage_BackEnd.Models.ArticleStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Animal");

                    b.Navigation("ArticleType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.ArticleTypeBetail", b =>
                {
                    b.HasOne("Abattage_BackEnd.Models.ArticleBetail", "ArticleBetail")
                        .WithMany("ArticleTypeBetails")
                        .HasForeignKey("ArticleBetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.TypeBetail", "TypeBetail")
                        .WithMany("ArticleTypeBetails")
                        .HasForeignKey("TypeBetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleBetail");

                    b.Navigation("TypeBetail");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.Carcasse", b =>
                {
                    b.HasOne("Abattage_BackEnd.AnimalStatus", "Status")
                        .WithMany()
                        .HasForeignKey("AnimalStatusId");

                    b.HasOne("Abattage_BackEnd.Models.Reception", "Reception")
                        .WithMany()
                        .HasForeignKey("ReceptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Stabulation", "Stabulation")
                        .WithMany()
                        .HasForeignKey("StabulationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.TypeAbattage", "TypeAbattage")
                        .WithMany()
                        .HasForeignKey("TypeAbattageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.TypeBetail", "TypeBetail")
                        .WithMany()
                        .HasForeignKey("TypeBetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reception");

                    b.Navigation("Stabulation");

                    b.Navigation("Status");

                    b.Navigation("TypeAbattage");

                    b.Navigation("TypeBetail");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.Chevillard", b =>
                {
                    b.HasOne("Abattage_BackEnd.Models.Client", "AcheteurAutre")
                        .WithMany()
                        .HasForeignKey("AcheteurAutreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Client", "AcheteurIntestin")
                        .WithMany()
                        .HasForeignKey("AcheteurIntestinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Client", "AcheteurPeau")
                        .WithMany()
                        .HasForeignKey("AcheteurPeauId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Client", "AcheteurTete")
                        .WithMany()
                        .HasForeignKey("AcheteurTeteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcheteurAutre");

                    b.Navigation("AcheteurIntestin");

                    b.Navigation("AcheteurPeau");

                    b.Navigation("AcheteurTete");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.Planification", b =>
                {
                    b.HasOne("Abattage_BackEnd.Models.Reception", "Reception")
                        .WithMany()
                        .HasForeignKey("ReceptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reception");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.Reception", b =>
                {
                    b.HasOne("Abattage_BackEnd.Models.Client", "AcheteurAutre")
                        .WithMany()
                        .HasForeignKey("AcheteurAutreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Client", "AcheteurIntestin")
                        .WithMany()
                        .HasForeignKey("AcheteurIntestinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Client", "AcheteurPeau")
                        .WithMany()
                        .HasForeignKey("AcheteurPeauId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Client", "AcheteurTete")
                        .WithMany()
                        .HasForeignKey("AcheteurTeteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Chevillard", "Chevillard")
                        .WithMany()
                        .HasForeignKey("ChevillardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Stabulation", "StabulationBovins")
                        .WithMany()
                        .HasForeignKey("StabulationBovinsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Stabulation", "StabulationMoutons")
                        .WithMany()
                        .HasForeignKey("StabulationMoutonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.Stabulation", "StabulationVaches")
                        .WithMany()
                        .HasForeignKey("StabulationVachesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcheteurAutre");

                    b.Navigation("AcheteurIntestin");

                    b.Navigation("AcheteurPeau");

                    b.Navigation("AcheteurTete");

                    b.Navigation("Chevillard");

                    b.Navigation("StabulationBovins");

                    b.Navigation("StabulationMoutons");

                    b.Navigation("StabulationVaches");
                });

            modelBuilder.Entity("ArticleBetailTypeBetail", b =>
                {
                    b.HasOne("Abattage_BackEnd.Models.ArticleBetail", null)
                        .WithMany()
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abattage_BackEnd.Models.TypeBetail", null)
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.ArticleBetail", b =>
                {
                    b.Navigation("ArticleTypeBetails");
                });

            modelBuilder.Entity("Abattage_BackEnd.Models.TypeBetail", b =>
                {
                    b.Navigation("ArticleTypeBetails");
                });
#pragma warning restore 612, 618
        }
    }
}
