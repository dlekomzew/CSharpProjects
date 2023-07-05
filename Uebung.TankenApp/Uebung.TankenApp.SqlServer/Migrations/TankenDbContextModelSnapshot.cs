﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uebung.TankenApp.SqlServer;

#nullable disable

namespace Uebung.TankenApp.SqlServer.Migrations
{
    [DbContext(typeof(TankenDbContext))]
    partial class TankenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Uebung.TankenApp.Entity.Tankvorgang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Datum")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("GefahreneKilometer")
                        .HasColumnType("float");

                    b.Property<double>("GetankteLiter")
                        .HasColumnType("float");

                    b.Property<double>("Kilometerstand")
                        .HasColumnType("float");

                    b.Property<decimal>("Preis")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Tankvorgang", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}