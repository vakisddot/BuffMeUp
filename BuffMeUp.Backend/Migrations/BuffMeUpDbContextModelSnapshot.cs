﻿// <auto-generated />
using System;
using BuffMeUp.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuffMeUp.Backend.Migrations
{
    [DbContext(typeof(BuffMeUpDbContext))]
    partial class BuffMeUpDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Auth.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Auth.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PersonalStatsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalStatsId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"),
                            Email = "admin@admin.admin",
                            FirstName = "Admin",
                            PasswordHash = "DIyfgQUqk1F8RGdvwGKYlg==;pplKG5BYL3YU3GEtkFNDAt6XPdk5H8yLjO3ZBge00ek=",
                            RoleId = 2,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.FoodItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Carbs")
                        .HasColumnType("int");

                    b.Property<int>("Fats")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("Protein")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FoodItems");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.JT_MealTemplate_FoodItem", b =>
                {
                    b.Property<Guid>("MealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.HasKey("MealId", "FoodItemId");

                    b.HasIndex("FoodItemId");

                    b.ToTable("JT_MealTemplate_FoodItem");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.JT_Meal_FoodItem", b =>
                {
                    b.Property<Guid>("MealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.HasKey("MealId", "FoodItemId");

                    b.HasIndex("FoodItemId");

                    b.ToTable("JT_Meal_FoodItem");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.JT_Meal_MealTemplate", b =>
                {
                    b.Property<Guid>("MealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MealTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MealId", "MealTemplateId");

                    b.HasIndex("MealTemplateId");

                    b.ToTable("JT_Meal_MealTemplate");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.MealTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsGlobal")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MealTemplates");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.PersonalStats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<int>("GoalWeight")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("StartingWeight")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PersonalStats");

                    b.HasData(
                        new
                        {
                            Id = new Guid("36d33f78-dcba-46a7-955c-13e0cc73ec97"),
                            Age = 22,
                            CurrentWeight = 70,
                            Gender = true,
                            GoalWeight = 75,
                            Height = 175,
                            StartingWeight = 70,
                            UserId = new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1")
                        });
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Workouts.ExerciseSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExerciseTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTemplateId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ExerciseSets");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Workouts.ExerciseTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("ExerciseType")
                        .HasColumnType("int");

                    b.Property<bool>("IsGlobal")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExerciseTemplates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8163c55a-7716-4ce8-8440-54cab09ea35d"),
                            Description = "Lie on your back on a flat bench. Grip the bar with your hands slightly wider than shoulder-width apart. Lift the bar off the rack and position it above your chest with arms fully extended.",
                            ExerciseType = 1,
                            IsGlobal = true,
                            Name = "Bench Press",
                            UserId = new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1")
                        },
                        new
                        {
                            Id = new Guid("cb374e7c-ff29-46c7-a646-7d4a0c6ae81e"),
                            Description = "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.",
                            ExerciseType = 0,
                            IsGlobal = true,
                            Name = "Deadlift",
                            UserId = new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1")
                        },
                        new
                        {
                            Id = new Guid("2563d0c5-c76c-4980-b3bf-28778ac73f86"),
                            Description = "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.",
                            ExerciseType = 2,
                            IsGlobal = true,
                            Name = "Squat",
                            UserId = new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1")
                        },
                        new
                        {
                            Id = new Guid("b96bd616-1dc1-4543-891f-4fc659bfec96"),
                            Description = "Stand with the bar on your front shoulders, and your hands next to your shoulders. Press the bar over your head, until it’s balanced over your shoulders and mid-foot.",
                            ExerciseType = 3,
                            IsGlobal = true,
                            Name = "Overhead Press",
                            UserId = new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1")
                        },
                        new
                        {
                            Id = new Guid("da5732ea-4e64-47a6-85c1-49a9f7261e86"),
                            Description = "Grab the pull-up bar with your palms down (shoulder-width grip). Hang to the pull-up bar with straight arms and your legs off the floor. Pull yourself up by pulling your elbows down to the floor.",
                            ExerciseType = 0,
                            IsGlobal = true,
                            Name = "Pull-up",
                            UserId = new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1")
                        },
                        new
                        {
                            Id = new Guid("e7f3286c-fa5b-499f-92bc-23ae8f58352d"),
                            Description = "Stand up with your torso upright while holding a dumbbell on each hand being held at arms length. The elbows should be close to the torso. This will be your starting position.",
                            ExerciseType = 5,
                            IsGlobal = true,
                            Name = "Dumbbell Curl",
                            UserId = new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1")
                        },
                        new
                        {
                            Id = new Guid("f527757f-9c9b-49ac-89d6-de2b67f75e86"),
                            Description = "Attach a straight or angled bar to a high pulley and grab with an overhand grip at shoulder width. Standing upright with the torso straight and a very small inclination forward, bring the upper arms close to your body and perpendicular to the floor.",
                            ExerciseType = 4,
                            IsGlobal = true,
                            Name = "Triceps Pushdown",
                            UserId = new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1")
                        },
                        new
                        {
                            Id = new Guid("56e4a8c0-69ba-47a1-9cfb-6e41ef950f6a"),
                            Description = "Lie on your back on the floor. Bend your legs and place feet firmly on the ground to stabilize your lower body. Cross your hands to opposite shoulders or place them behind your ears, without pulling on your neck.",
                            ExerciseType = 6,
                            IsGlobal = true,
                            Name = "Sit-up",
                            UserId = new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1")
                        });
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Workouts.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Auth.User", b =>
                {
                    b.HasOne("BuffMeUp.Backend.Data.Models.PersonalStats", "PersonalStats")
                        .WithMany()
                        .HasForeignKey("PersonalStatsId");

                    b.HasOne("BuffMeUp.Backend.Data.Models.Auth.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalStats");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.JT_MealTemplate_FoodItem", b =>
                {
                    b.HasOne("BuffMeUp.Backend.Data.Models.Food.FoodItem", "FoodItem")
                        .WithMany("MealTemplate_FoodItemm")
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuffMeUp.Backend.Data.Models.Food.MealTemplate", "Meal")
                        .WithMany("MealTemplate_FoodItem")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.JT_Meal_FoodItem", b =>
                {
                    b.HasOne("BuffMeUp.Backend.Data.Models.Food.FoodItem", "FoodItem")
                        .WithMany()
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuffMeUp.Backend.Data.Models.Food.Meal", "Meal")
                        .WithMany("Meal_FoodItem")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.JT_Meal_MealTemplate", b =>
                {
                    b.HasOne("BuffMeUp.Backend.Data.Models.Food.Meal", "Meal")
                        .WithMany("Meal_MealTemplate")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuffMeUp.Backend.Data.Models.Food.MealTemplate", "MealTemplate")
                        .WithMany()
                        .HasForeignKey("MealTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");

                    b.Navigation("MealTemplate");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.Meal", b =>
                {
                    b.HasOne("BuffMeUp.Backend.Data.Models.Auth.User", "User")
                        .WithMany("Meals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.MealTemplate", b =>
                {
                    b.HasOne("BuffMeUp.Backend.Data.Models.Auth.User", "User")
                        .WithMany("MealTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.PersonalStats", b =>
                {
                    b.HasOne("BuffMeUp.Backend.Data.Models.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Workouts.ExerciseSet", b =>
                {
                    b.HasOne("BuffMeUp.Backend.Data.Models.Workouts.ExerciseTemplate", "ExerciseTemplate")
                        .WithMany()
                        .HasForeignKey("ExerciseTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuffMeUp.Backend.Data.Models.Workouts.Workout", "Workout")
                        .WithMany("ExerciseSets")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseTemplate");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Workouts.ExerciseTemplate", b =>
                {
                    b.HasOne("BuffMeUp.Backend.Data.Models.Auth.User", "User")
                        .WithMany("ExerciseTemplates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Workouts.Workout", b =>
                {
                    b.HasOne("BuffMeUp.Backend.Data.Models.Auth.User", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Auth.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Auth.User", b =>
                {
                    b.Navigation("ExerciseTemplates");

                    b.Navigation("MealTemplates");

                    b.Navigation("Meals");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.FoodItem", b =>
                {
                    b.Navigation("MealTemplate_FoodItemm");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.Meal", b =>
                {
                    b.Navigation("Meal_FoodItem");

                    b.Navigation("Meal_MealTemplate");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Food.MealTemplate", b =>
                {
                    b.Navigation("MealTemplate_FoodItem");
                });

            modelBuilder.Entity("BuffMeUp.Backend.Data.Models.Workouts.Workout", b =>
                {
                    b.Navigation("ExerciseSets");
                });
#pragma warning restore 612, 618
        }
    }
}
