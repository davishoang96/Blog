﻿// <auto-generated />
using System;
using Blog.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blog.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

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
                            ModifiedDate = new DateTime(2024, 12, 9, 20, 34, 51, 446, DateTimeKind.Local).AddTicks(8680),
                            PublishDate = new DateTime(2024, 12, 9, 20, 34, 51, 446, DateTimeKind.Local).AddTicks(8710),
                            Title = "Make the world better"
                        },
                        new
                        {
                            Id = 2,
                            Body = "Test",
                            Description = "Test",
                            ModifiedDate = new DateTime(2024, 12, 9, 20, 34, 51, 446, DateTimeKind.Local).AddTicks(8720),
                            PublishDate = new DateTime(2024, 12, 9, 20, 34, 51, 446, DateTimeKind.Local).AddTicks(8720),
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
