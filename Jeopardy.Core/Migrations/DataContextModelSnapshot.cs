﻿// <auto-generated />
using System;
using Jeopardy.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jeopardy.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Jeopardy.Core.Models.Airdate", b =>
                {
                    b.Property<int>("Game")
                        .HasColumnType("INTEGER")
                        .HasColumnName("game");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("airdate");

                    b.HasKey("Game");

                    b.ToTable("airdates", (string)null);
                });

            modelBuilder.Entity("Jeopardy.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("category");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CategoryName" }, "IX_categories_category")
                        .IsUnique();

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Jeopardy.Core.Models.Classification", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("category_id");

                    b.Property<int>("ClueId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("clue_id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClueId");

                    b.ToTable("classifications", (string)null);
                });

            modelBuilder.Entity("Jeopardy.Core.Models.Clue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("Game")
                        .HasColumnType("INTEGER")
                        .HasColumnName("game");

                    b.Property<int>("Round")
                        .HasColumnType("INTEGER")
                        .HasColumnName("round");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("Game");

                    b.ToTable("clues", (string)null);
                });

            modelBuilder.Entity("Jeopardy.Core.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Answer")
                        .HasColumnType("TEXT")
                        .HasColumnName("answer");

                    b.Property<string>("Clue")
                        .HasColumnType("TEXT")
                        .HasColumnName("clue");

                    b.HasKey("Id");

                    b.ToTable("documents", (string)null);
                });

            modelBuilder.Entity("Jeopardy.Core.Models.Classification", b =>
                {
                    b.HasOne("Jeopardy.Core.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jeopardy.Core.Models.Clue", "Clue")
                        .WithMany()
                        .HasForeignKey("ClueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Clue");
                });

            modelBuilder.Entity("Jeopardy.Core.Models.Clue", b =>
                {
                    b.HasOne("Jeopardy.Core.Models.Airdate", "GameNavigation")
                        .WithMany("Clues")
                        .HasForeignKey("Game")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jeopardy.Core.Models.Document", "IdNavigation")
                        .WithOne("ClueNavigation")
                        .HasForeignKey("Jeopardy.Core.Models.Clue", "Id")
                        .IsRequired();

                    b.Navigation("GameNavigation");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("Jeopardy.Core.Models.Airdate", b =>
                {
                    b.Navigation("Clues");
                });

            modelBuilder.Entity("Jeopardy.Core.Models.Document", b =>
                {
                    b.Navigation("ClueNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
