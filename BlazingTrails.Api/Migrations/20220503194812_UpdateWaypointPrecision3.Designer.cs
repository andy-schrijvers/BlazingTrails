﻿// <auto-generated />
using BlazingTrails.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazingTrails.Api.Migrations
{
    [DbContext(typeof(BlazingTrailContext))]
    [Migration("20220503194812_UpdateWaypointPrecision3")]
    partial class UpdateWaypointPrecision3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazingTrails.Api.Persistence.Entities.Trail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeInMinutes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("BlazingTrails.Api.Persistence.Entities.Waypoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(8,5)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(8,5)");

                    b.Property<int>("TrailId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrailId");

                    b.ToTable("Waypoints");
                });

            modelBuilder.Entity("BlazingTrails.Api.Persistence.Entities.Waypoint", b =>
                {
                    b.HasOne("BlazingTrails.Api.Persistence.Entities.Trail", "Trail")
                        .WithMany("Waypoints")
                        .HasForeignKey("TrailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trail");
                });

            modelBuilder.Entity("BlazingTrails.Api.Persistence.Entities.Trail", b =>
                {
                    b.Navigation("Waypoints");
                });
#pragma warning restore 612, 618
        }
    }
}
