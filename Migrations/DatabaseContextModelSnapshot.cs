﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Svendeprøve_projekt_BodyFitBlazor.Data;

#nullable disable

namespace Svendeprøve_projekt_BodyFitBlazor.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.TrainingExerciseAddedToLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("TrainingExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingLogId")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingLogId1")
                        .HasColumnType("int");

                    b.Property<int>("weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingExerciseId");

                    b.HasIndex("TrainingLogId");

                    b.HasIndex("TrainingLogId1");

                    b.ToTable("trainingExerciseAddedToLogs");
                });

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.TrainingExercises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("trainingExercises");
                });

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.TrainingLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("trainingLog");
                });

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Postal")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.TrainingExerciseAddedToLog", b =>
                {
                    b.HasOne("Svendeprøve_projekt_BodyFitBlazor.Models.TrainingExercises", "TrainingExercises")
                        .WithMany()
                        .HasForeignKey("TrainingExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Svendeprøve_projekt_BodyFitBlazor.Models.TrainingLog", "trainingLog")
                        .WithMany()
                        .HasForeignKey("TrainingLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Svendeprøve_projekt_BodyFitBlazor.Models.TrainingLog", null)
                        .WithMany("ExerciseAddedToLog")
                        .HasForeignKey("TrainingLogId1");

                    b.Navigation("TrainingExercises");

                    b.Navigation("trainingLog");
                });

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.TrainingExercises", b =>
                {
                    b.HasOne("Svendeprøve_projekt_BodyFitBlazor.Models.Categories", "Categories")
                        .WithMany("Exercises")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.TrainingLog", b =>
                {
                    b.HasOne("Svendeprøve_projekt_BodyFitBlazor.Models.UserInfo", null)
                        .WithMany("log")
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.Categories", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.TrainingLog", b =>
                {
                    b.Navigation("ExerciseAddedToLog");
                });

            modelBuilder.Entity("Svendeprøve_projekt_BodyFitBlazor.Models.UserInfo", b =>
                {
                    b.Navigation("log");
                });
#pragma warning restore 612, 618
        }
    }
}
