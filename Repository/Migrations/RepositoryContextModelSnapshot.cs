﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Aggregates.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset?>("InstallationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("LastMaintenanceDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Device", (string)null);
                });

            modelBuilder.Entity("Domain.Aggregates.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Region", (string)null);
                });

            modelBuilder.Entity("Domain.Aggregates.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Aggregates.Device", b =>
                {
                    b.HasOne("Domain.Aggregates.Region", "Region")
                        .WithMany("Devices")
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Aggregates.User", b =>
                {
                    b.HasOne("Domain.Aggregates.Region", "Region")
                        .WithMany("Users")
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Aggregates.Region", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
