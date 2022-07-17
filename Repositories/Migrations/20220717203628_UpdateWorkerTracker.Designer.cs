﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace Repositories.Migrations
{
    [DbContext(typeof(FarmDbContext))]
    [Migration("20220717203628_UpdateWorkerTracker")]
    partial class UpdateWorkerTracker
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Factory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FactoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Factory", (string)null);
                });

            modelBuilder.Entity("Entities.FactoryCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AmountPaid")
                        .HasPrecision(38, 10)
                        .HasColumnType("decimal(38,10)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FactoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PaidDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Weight")
                        .HasPrecision(38, 10)
                        .HasColumnType("decimal(38,10)");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("FactoryCollection", (string)null);
                });

            modelBuilder.Entity("Entities.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Worker", (string)null);
                });

            modelBuilder.Entity("Entities.WorkerTracker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Activity")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("KiloGramsPicked")
                        .HasPrecision(38, 10)
                        .HasColumnType("decimal(38,10)");

                    b.Property<DateTime>("PickedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("WorkerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerTracker", (string)null);
                });

            modelBuilder.Entity("Entities.FactoryCollection", b =>
                {
                    b.HasOne("Entities.Factory", "Factory")
                        .WithMany()
                        .HasForeignKey("FactoryId");

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("Entities.WorkerTracker", b =>
                {
                    b.HasOne("Entities.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId");

                    b.Navigation("Worker");
                });
#pragma warning restore 612, 618
        }
    }
}