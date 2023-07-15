using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuffMeUp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false),
                    Carbs = table.Column<int>(type: "int", nullable: false),
                    Fats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    ExerciseTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExerciseType = table.Column<int>(type: "int", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JT_Meal_FoodItem",
                columns: table => new
                {
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JT_Meal_FoodItem", x => new { x.MealId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_JT_Meal_FoodItem_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JT_Meal_MealTemplate",
                columns: table => new
                {
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JT_Meal_MealTemplate", x => new { x.MealId, x.MealTemplateId });
                });

            migrationBuilder.CreateTable(
                name: "JT_MealTemplate_FoodItem",
                columns: table => new
                {
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JT_MealTemplate_FoodItem", x => new { x.MealId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_JT_MealTemplate_FoodItem_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    StartingWeight = table.Column<int>(type: "int", nullable: false),
                    CurrentWeight = table.Column<int>(type: "int", nullable: false),
                    GoalWeight = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PersonalStatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_PersonalStats_PersonalStatsId",
                        column: x => x.PersonalStatsId,
                        principalTable: "PersonalStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "PasswordHash", "PersonalStatsId", "RoleId", "Username" },
                values: new object[] { new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"), "admin@admin.admin", "Admin", "sVycnDV6Lz/6AXj5bPla9w==;RMBeF4j2IPvuGOwvWi6M6HRxb3q2QR2oyoQB3DlhPtc=", null, 2, "admin" });

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "Description", "ExerciseType", "IsGlobal", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("3904d82f-ddee-4a28-8489-3b1415a5e4c7"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 0, true, "Deadlift", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("58796372-903c-4fc7-b7d5-3e49e9bb117f"), "Grab the pull-up bar with your palms down (shoulder-width grip). Hang to the pull-up bar with straight arms and your legs off the floor. Pull yourself up by pulling your elbows down to the floor.", 0, true, "Pull-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("83a04f54-9a35-4343-aede-ab25c8a6383e"), "Attach a straight or angled bar to a high pulley and grab with an overhand grip at shoulder width. Standing upright with the torso straight and a very small inclination forward, bring the upper arms close to your body and perpendicular to the floor.", 4, true, "Triceps Pushdown", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("83c7b172-417e-40fa-8083-864feb45e5b7"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 2, true, "Squat", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("a7300e71-b70b-4c52-9568-b5cf9dcf2a32"), "Lie on your back on the floor. Bend your legs and place feet firmly on the ground to stabilize your lower body. Cross your hands to opposite shoulders or place them behind your ears, without pulling on your neck.", 6, true, "Sit-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("be74f872-fb6a-4ea3-b274-096974d5c4ad"), "Stand up with your torso upright while holding a dumbbell on each hand being held at arms length. The elbows should be close to the torso. This will be your starting position.", 5, true, "Dumbbell Curl", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("d1cd0c0d-9dea-4c43-92d5-fb0f01b68e32"), "Lie on your back on a flat bench. Grip the bar with your hands slightly wider than shoulder-width apart. Lift the bar off the rack and position it above your chest with arms fully extended.", 1, true, "Bench Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("eb628fe7-0d93-4c60-b116-bdd9c9d45dc5"), "Stand with the bar on your front shoulders, and your hands next to your shoulders. Press the bar over your head, until it’s balanced over your shoulders and mid-foot.", 3, true, "Overhead Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") }
                });

            migrationBuilder.InsertData(
                table: "PersonalStats",
                columns: new[] { "Id", "Age", "CurrentWeight", "Gender", "GoalWeight", "Height", "StartingWeight", "UserId" },
                values: new object[] { new Guid("36d33f78-dcba-46a7-955c-13e0cc73ec97"), 22, 70, true, 75, 175, 70, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_ExerciseTemplateId",
                table: "ExerciseSets",
                column: "ExerciseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_WorkoutId",
                table: "ExerciseSets",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTemplates_UserId",
                table: "ExerciseTemplates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JT_Meal_FoodItem_FoodItemId",
                table: "JT_Meal_FoodItem",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_JT_Meal_MealTemplate_MealTemplateId",
                table: "JT_Meal_MealTemplate",
                column: "MealTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_JT_MealTemplate_FoodItem_FoodItemId",
                table: "JT_MealTemplate_FoodItem",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserId",
                table: "Meals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealTemplates_UserId",
                table: "MealTemplates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalStats_UserId",
                table: "PersonalStats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonalStatsId",
                table: "Users",
                column: "PersonalStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_ExerciseTemplates_ExerciseTemplateId",
                table: "ExerciseSets",
                column: "ExerciseTemplateId",
                principalTable: "ExerciseTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_Workouts_WorkoutId",
                table: "ExerciseSets",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTemplates_Users_UserId",
                table: "ExerciseTemplates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JT_Meal_FoodItem_Meals_MealId",
                table: "JT_Meal_FoodItem",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JT_Meal_MealTemplate_MealTemplates_MealTemplateId",
                table: "JT_Meal_MealTemplate",
                column: "MealTemplateId",
                principalTable: "MealTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JT_Meal_MealTemplate_Meals_MealId",
                table: "JT_Meal_MealTemplate",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JT_MealTemplate_FoodItem_MealTemplates_MealId",
                table: "JT_MealTemplate_FoodItem",
                column: "MealId",
                principalTable: "MealTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Users_UserId",
                table: "Meals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTemplates_Users_UserId",
                table: "MealTemplates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalStats_Users_UserId",
                table: "PersonalStats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalStats_Users_UserId",
                table: "PersonalStats");

            migrationBuilder.DropTable(
                name: "ExerciseSets");

            migrationBuilder.DropTable(
                name: "JT_Meal_FoodItem");

            migrationBuilder.DropTable(
                name: "JT_Meal_MealTemplate");

            migrationBuilder.DropTable(
                name: "JT_MealTemplate_FoodItem");

            migrationBuilder.DropTable(
                name: "ExerciseTemplates");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "MealTemplates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PersonalStats");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
