﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migration
{
    [DbContext(typeof(DataContext))]
    [Migration("20230921132004_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("API.Entities.NodeName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NodeNames");
                });

            modelBuilder.Entity("API.Entities.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Currency")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirmId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Growth")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("GrowthPercent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UninvestedCash")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("NodeNamePortfolio", b =>
                {
                    b.Property<int>("NodeNamesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NodeNamesId", "PortfolioId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("PortfolioNodeNames", (string)null);
                });

            modelBuilder.Entity("PortfolioNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NodeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("NodeName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PortfolioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.ToTable("PortfolioNodes");
                });

            modelBuilder.Entity("NodeNamePortfolio", b =>
                {
                    b.HasOne("API.Entities.NodeName", null)
                        .WithMany()
                        .HasForeignKey("NodeNamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Portfolio", null)
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfolioNode", b =>
                {
                    b.HasOne("API.Entities.Portfolio", null)
                        .WithMany("Nodes")
                        .HasForeignKey("PortfolioId");
                });

            modelBuilder.Entity("API.Entities.Portfolio", b =>
                {
                    b.Navigation("Nodes");
                });
#pragma warning restore 612, 618
        }
    }
}
