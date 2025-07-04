﻿// <auto-generated />
using System;
using BookArchiveAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookArchiveAPI.Migrations
{
    [DbContext(typeof(BookArchiveDbContext))]
    partial class BookArchiveDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("BookArchiveAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Format")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Genre")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Language")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PageCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PreviewImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Publisher")
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("YearPublished")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
