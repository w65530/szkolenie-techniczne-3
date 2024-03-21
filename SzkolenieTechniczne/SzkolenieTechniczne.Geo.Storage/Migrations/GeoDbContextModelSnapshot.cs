﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SzkolenieTechniczne.Geo.Storage;

#nullable disable

namespace SzkolenieTechniczne.Geo.Storage.Migrations
{
    [DbContext(typeof(GeoDbContext))]
    partial class GeoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SzkolenieTechniczne.Geo.Storage.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities", "Geo");
                });

            modelBuilder.Entity("SzkolenieTechniczne.Geo.Storage.Entities.CityTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("LanguageCode");

                    b.HasIndex("Name");

                    b.ToTable("CityTranslations", "Geo");
                });

            modelBuilder.Entity("SzkolenieTechniczne.Geo.Storage.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alpha3Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.HasIndex("Alpha3Code")
                        .IsUnique();

                    b.ToTable("Countries", "Geo");
                });

            modelBuilder.Entity("SzkolenieTechniczne.Geo.Storage.Entities.CountryTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("LanguageCode");

                    b.HasIndex("Name");

                    b.ToTable("CountryTranslations", "Geo");
                });

            modelBuilder.Entity("SzkolenieTechniczne.Geo.Storage.Entities.City", b =>
                {
                    b.HasOne("SzkolenieTechniczne.Geo.Storage.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SzkolenieTechniczne.Geo.Storage.Entities.CityTranslation", b =>
                {
                    b.HasOne("SzkolenieTechniczne.Geo.Storage.Entities.City", null)
                        .WithMany("Translations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SzkolenieTechniczne.Geo.Storage.Entities.CountryTranslation", b =>
                {
                    b.HasOne("SzkolenieTechniczne.Geo.Storage.Entities.Country", null)
                        .WithMany("Translations")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SzkolenieTechniczne.Geo.Storage.Entities.City", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("SzkolenieTechniczne.Geo.Storage.Entities.Country", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
