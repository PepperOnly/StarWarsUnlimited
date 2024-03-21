﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Unlimited.Repository;

#nullable disable

namespace Unlimited.Repository.Migrations
{
    [DbContext(typeof(UnlimitedDbContext))]
    partial class UnlimitedDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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
                        .HasColumnType("text");

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
                        .HasColumnType("text");

                    b.Property<List<Dictionary<string, string>>>("Keywords")
                        .HasColumnType("hstore[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Power")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Set")
                        .HasColumnType("integer");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int[]>("Traits")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<bool>("Unique")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
