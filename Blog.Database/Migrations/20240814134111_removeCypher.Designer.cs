﻿// <auto-generated />
using System;
using Blog.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blog.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240814134111_removeCypher")]
    partial class removeCypher
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Blog.Database.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Blog.Database.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "Test",
                            Description = "Test",
                            ModifiedDate = new DateTime(2024, 8, 14, 21, 41, 10, 748, DateTimeKind.Local).AddTicks(1868),
                            PublishDate = new DateTime(2024, 8, 14, 21, 41, 10, 748, DateTimeKind.Local).AddTicks(1877),
                            Title = "Make the world better"
                        },
                        new
                        {
                            Id = 2,
                            Body = "Test",
                            Description = "Test",
                            ModifiedDate = new DateTime(2024, 8, 14, 21, 41, 10, 748, DateTimeKind.Local).AddTicks(1879),
                            PublishDate = new DateTime(2024, 8, 14, 21, 41, 10, 748, DateTimeKind.Local).AddTicks(1879),
                            Title = "AI take over the world"
                        });
                });

            modelBuilder.Entity("Blog.Database.Models.WorkLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoggedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LoggedDate")
                        .IsUnique()
                        .HasDatabaseName("IX_Unique_LoggedDate");

                    b.ToTable("WorkLogs");
                });

            modelBuilder.Entity("Blog.Database.Models.Post", b =>
                {
                    b.HasOne("Blog.Database.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Blog.Database.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
