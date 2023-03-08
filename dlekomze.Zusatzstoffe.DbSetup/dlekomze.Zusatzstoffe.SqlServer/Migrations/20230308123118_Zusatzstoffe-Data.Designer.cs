﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dlekomze.Zusatzstoffe.SqlServer;

#nullable disable

namespace dlekomze.Zusatzstoffe.SqlServer.Migrations
{
    [DbContext(typeof(ZusatzstoffeDbContext))]
    [Migration("20230308123118_Zusatzstoffe-Data")]
    partial class ZusatzstoffeData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ENummern")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HerkunftStoff", b =>
                {
                    b.Property<int>("HerkunftSetID")
                        .HasColumnType("int");

                    b.Property<int>("StoffSetID")
                        .HasColumnType("int");

                    b.HasKey("HerkunftSetID", "StoffSetID");

                    b.HasIndex("StoffSetID");

                    b.ToTable("HerkunftStoff", "ENummern");
                });

            modelBuilder.Entity("StoffVerwendung", b =>
                {
                    b.Property<int>("StoffSetID")
                        .HasColumnType("int");

                    b.Property<int>("VerwendungSetID")
                        .HasColumnType("int");

                    b.HasKey("StoffSetID", "VerwendungSetID");

                    b.HasIndex("VerwendungSetID");

                    b.ToTable("StoffVerwendung", "ENummern");
                });

            modelBuilder.Entity("dlekomze.Zusatzstoffe.Enitity.Bewertung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Bewertung", "ENummern");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Bezeichnung = "unbedenklich"
                        });
                });

            modelBuilder.Entity("dlekomze.Zusatzstoffe.Enitity.Herkunft", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Herkunft", "ENummern");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Bezeichnung = "künstlich"
                        },
                        new
                        {
                            ID = 2,
                            Bezeichnung = "pflanzlich"
                        },
                        new
                        {
                            ID = 3,
                            Bezeichnung = "tierisch"
                        });
                });

            modelBuilder.Entity("dlekomze.Zusatzstoffe.Enitity.Stoff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BewertungID")
                        .HasColumnType("int");

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Genetechnik")
                        .HasColumnType("bit");

                    b.Property<bool>("Nanotechnik")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("BewertungID");

                    b.ToTable("Stoff", "ENummern");
                });

            modelBuilder.Entity("dlekomze.Zusatzstoffe.Enitity.Verwendung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Verwendung", "ENummern");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Beschreibung = "Stoffe, die ein Lebensmittel ansäuern und/oder diesem einen sauren Geschmack verleihen",
                            Bezeichnung = "Säurungsmittel"
                        },
                        new
                        {
                            ID = 2,
                            Beschreibung = "verbinden Stoffe, die nicht miteinander mischbar sind, wie zum Beispiel Öl und Wasser",
                            Bezeichnung = "Emulgator"
                        },
                        new
                        {
                            ID = 3,
                            Beschreibung = "verhindern das Ranzigwerden von Fetten und sorgen für eine längere Haltbarkeit",
                            Bezeichnung = "Antioxidationsmittel"
                        },
                        new
                        {
                            ID = 4,
                            Beschreibung = "werden dazu verwendet, die Lebensmitteln zu stabilisieren, erhalten oder intensivieren",
                            Bezeichnung = "Stabilisator"
                        },
                        new
                        {
                            ID = 5,
                            Beschreibung = "???",
                            Bezeichnung = "Mehlbehandlungsmittel"
                        });
                });

            modelBuilder.Entity("HerkunftStoff", b =>
                {
                    b.HasOne("dlekomze.Zusatzstoffe.Enitity.Herkunft", null)
                        .WithMany()
                        .HasForeignKey("HerkunftSetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dlekomze.Zusatzstoffe.Enitity.Stoff", null)
                        .WithMany()
                        .HasForeignKey("StoffSetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoffVerwendung", b =>
                {
                    b.HasOne("dlekomze.Zusatzstoffe.Enitity.Stoff", null)
                        .WithMany()
                        .HasForeignKey("StoffSetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dlekomze.Zusatzstoffe.Enitity.Verwendung", null)
                        .WithMany()
                        .HasForeignKey("VerwendungSetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dlekomze.Zusatzstoffe.Enitity.Stoff", b =>
                {
                    b.HasOne("dlekomze.Zusatzstoffe.Enitity.Bewertung", "BewertungNavigation")
                        .WithMany()
                        .HasForeignKey("BewertungID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BewertungNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
