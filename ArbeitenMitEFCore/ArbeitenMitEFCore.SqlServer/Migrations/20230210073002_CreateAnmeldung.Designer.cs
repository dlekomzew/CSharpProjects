﻿// <auto-generated />
using System;
using ArbeitenMitEFCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArbeitenMitEFCore.SqlServer.Migrations
{
    [DbContext(typeof(SchuleDbContext))]
    [Migration("20230210073002_CreateAnmeldung")]
    partial class CreateAnmeldung
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Schule")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArbeitenMitEFCore.Entity.Anmeldung", b =>
                {
                    b.Property<int>("SchuelerId")
                        .HasColumnType("int");

                    b.Property<int>("VortragId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Anmeldezeitpunkt")
                        .HasColumnType("datetime2");

                    b.HasKey("SchuelerId", "VortragId");

                    b.HasIndex("VortragId");

                    b.ToTable("Anmeldung", "Schule");
                });

            modelBuilder.Entity("ArbeitenMitEFCore.Entity.Arbeitsgruppe", b =>
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

                    b.ToTable("Arbeitsgruppe", "Schule");
                });

            modelBuilder.Entity("ArbeitenMitEFCore.Entity.Fehlzeit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Bis")
                        .HasColumnType("datetime2");

                    b.Property<string>("Grund")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SchuelerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Von")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SchuelerId");

                    b.ToTable("Fehlzeit", "Schule");
                });

            modelBuilder.Entity("ArbeitenMitEFCore.Entity.Schueler", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("Geburtsdatum")
                        .HasColumnType("date");

                    b.Property<string>("Kennung")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("ID");

                    b.HasIndex("Kennung")
                        .IsUnique();

                    b.ToTable("Schueler", "Schule");
                });

            modelBuilder.Entity("ArbeitenMitEFCore.Entity.Vortrag", b =>
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

                    b.ToTable("Vortrag", "Schule");
                });

            modelBuilder.Entity("ArbeitsgruppeSchueler", b =>
                {
                    b.Property<int>("ArbeitsgruppeSetID")
                        .HasColumnType("int");

                    b.Property<int>("SchuelerSetID")
                        .HasColumnType("int");

                    b.HasKey("ArbeitsgruppeSetID", "SchuelerSetID");

                    b.HasIndex("SchuelerSetID");

                    b.ToTable("ArbeitsgruppeSchueler", "Schule");
                });

            modelBuilder.Entity("ArbeitenMitEFCore.Entity.Anmeldung", b =>
                {
                    b.HasOne("ArbeitenMitEFCore.Entity.Schueler", "SchuelerNavigation")
                        .WithMany("AnmeldungSet")
                        .HasForeignKey("SchuelerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArbeitenMitEFCore.Entity.Vortrag", "VortragNavigation")
                        .WithMany("AnmeldungSet")
                        .HasForeignKey("VortragId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchuelerNavigation");

                    b.Navigation("VortragNavigation");
                });

            modelBuilder.Entity("ArbeitenMitEFCore.Entity.Fehlzeit", b =>
                {
                    b.HasOne("ArbeitenMitEFCore.Entity.Schueler", "SchuelerNavigation")
                        .WithMany("FehlzeitSet")
                        .HasForeignKey("SchuelerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchuelerNavigation");
                });

            modelBuilder.Entity("ArbeitsgruppeSchueler", b =>
                {
                    b.HasOne("ArbeitenMitEFCore.Entity.Arbeitsgruppe", null)
                        .WithMany()
                        .HasForeignKey("ArbeitsgruppeSetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArbeitenMitEFCore.Entity.Schueler", null)
                        .WithMany()
                        .HasForeignKey("SchuelerSetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArbeitenMitEFCore.Entity.Schueler", b =>
                {
                    b.Navigation("AnmeldungSet");

                    b.Navigation("FehlzeitSet");
                });

            modelBuilder.Entity("ArbeitenMitEFCore.Entity.Vortrag", b =>
                {
                    b.Navigation("AnmeldungSet");
                });
#pragma warning restore 612, 618
        }
    }
}
