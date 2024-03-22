﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Unlimited.Repository;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    [DbContext(typeof(UnlimitedDbContext))]
    [Migration("20240322111734_UnlimitedDBv1.3")]
    partial class UnlimitedDBv13
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Card", b =>
                {
                    b.Property<int>("Set")
                        .HasColumnType("integer");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<int[]>("Arenas")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int[]>("Aspects")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("BackArt")
                        .HasColumnType("text");

                    b.Property<string>("BackText")
                        .HasColumnType("text");

                    b.Property<string>("Cost")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("0");

                    b.Property<bool>("DoubleSided")
                        .HasColumnType("boolean");

                    b.Property<string>("EpicAction")
                        .HasColumnType("text");

                    b.Property<string>("FrontArt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FrontText")
                        .HasColumnType("text");

                    b.Property<string>("HP")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("0");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int[]>("Keywords")
                        .HasColumnType("integer[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Power")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("0");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("None");

                    b.Property<int[]>("Traits")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<bool>("Unique")
                        .HasColumnType("boolean");

                    b.HasKey("Set", "Number");

                    b.ToTable("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
