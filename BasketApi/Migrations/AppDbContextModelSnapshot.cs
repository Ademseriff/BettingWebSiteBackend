﻿// <auto-generated />
using System;
using BasketApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasketApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BasketApi.Models.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("MatchSide")
                        .HasColumnType("int");

                    b.Property<string>("Rate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Team1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Team2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("baskets");
                });
#pragma warning restore 612, 618
        }
    }
}
