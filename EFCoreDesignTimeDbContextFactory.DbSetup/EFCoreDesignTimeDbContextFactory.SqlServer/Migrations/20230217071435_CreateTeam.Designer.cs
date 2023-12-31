﻿// <auto-generated />
using EFCoreDesignTimeDbContextFactory.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreDesignTimeDbContextFactory.SqlServer.Migrations
{
    [DbContext(typeof(Formel1DbContext))]
    [Migration("20230217071435_CreateTeam")]
    partial class CreateTeam
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Formel1")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreDesignTimeDbContextFactory.Entity.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Team", "Formel1");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bezeichnung = "Red Bull"
                        },
                        new
                        {
                            Id = 2,
                            Bezeichnung = "Mercedes"
                        },
                        new
                        {
                            Id = 3,
                            Bezeichnung = "Ferrari"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
