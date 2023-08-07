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
                    Number = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    ExerciseTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
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
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false),
                    Carbs = table.Column<int>(type: "int", nullable: false),
                    Fats = table.Column<int>(type: "int", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
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
                name: "Portions",
                columns: table => new
                {
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    Grams = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portions", x => new { x.MealId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_Portions_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portions_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
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
                columns: new[] { "Id", "Avatar", "Email", "FirstName", "PasswordHash", "PersonalStatsId", "RoleId", "Username" },
                values: new object[] { new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"), null, "admin@admin.admin", "Admin", "6UH6DpmEoJVxfcjLop+Z9g==;FlPtEPCtJhewB/rxyA3Ib8h+ihtG4dyFECWdjk2Kapg=", null, 2, "admin" });

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "Description", "ExerciseType", "IsGlobal", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("14332b57-99f0-43c1-be74-39bebe5dfa6b"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 2, true, "Squat", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("300ee550-f97b-4948-868f-bd3672d1c435"), "Lie on your back on the floor. Bend your legs and place feet firmly on the ground to stabilize your lower body. Cross your hands to opposite shoulders or place them behind your ears, without pulling on your neck.", 6, true, "Sit-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("5a8b0a2e-0078-409d-91b4-2e23272386fb"), "Stand with the bar on your front shoulders, and your hands next to your shoulders. Press the bar over your head, until it’s balanced over your shoulders and mid-foot.", 3, true, "Overhead Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("7534b175-3b6c-48bf-8a72-58091c173449"), "Grab the pull-up bar with your palms down (shoulder-width grip). Hang to the pull-up bar with straight arms and your legs off the floor. Pull yourself up by pulling your elbows down to the floor.", 0, true, "Pull-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("a1e2d962-6a9b-4239-89ba-b04d0f6f8c65"), "Stand up with your torso upright while holding a dumbbell on each hand being held at arms length. The elbows should be close to the torso. This will be your starting position.", 5, true, "Dumbbell Curl", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("b152a663-5ce4-4629-900c-cf0018bba49b"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 0, true, "Deadlift", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("b6bcf17b-8fb3-4645-b606-3b92cac603c3"), "Lie on your back on a flat bench. Grip the bar with your hands slightly wider than shoulder-width apart. Lift the bar off the rack and position it above your chest with arms fully extended.", 1, true, "Bench Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("e5290463-eda2-4125-849e-624ef33f5d40"), "Attach a straight or angled bar to a high pulley and grab with an overhand grip at shoulder width. Standing upright with the torso straight and a very small inclination forward, bring the upper arms close to your body and perpendicular to the floor.", 4, true, "Triceps Pushdown", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") }
                });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Carbs", "Fats", "IsGlobal", "Name", "Protein", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 10, true, "Eggs", 12, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 2, 0, 4, true, "Chicken breast", 31, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 3, 0, 13, true, "Salmon", 20, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 4, 0, 20, true, "Ground beef", 26, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 5, 0, 1, true, "Tuna", 30, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 6, 0, 21, true, "Pork chops", 25, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 7, 4, 0, true, "Greek yogurt", 10, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 8, 4, 0, true, "Cottage cheese", 11, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 9, 7, 0, true, "Broccoli", 2, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 10, 20, 0, true, "Sweet potato", 2, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 11, 24, 1, true, "Brown rice", 3, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 12, 22, 50, true, "Almonds", 21, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 13, 16, 49, true, "Peanuts", 25, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 14, 9, 15, true, "Avocado", 2, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 15, 23, 0, true, "Banana", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 16, 15, 0, true, "Apple", 0, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 17, 4, 3, true, "Beef liver", 20, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 18, 20, 0, true, "Lentils", 9, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 19, 27, 3, true, "Chickpeas", 9, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 20, 21, 2, true, "Quinoa", 4, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 21, 12, 1, true, "Oatmeal", 3, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 22, 20, 50, true, "Peanut butter", 25, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 23, 30, 44, true, "Cashews", 18, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 24, 4, 0, true, "Spinach", 3, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 25, 11, 0, true, "Carrots", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 26, 4, 0, true, "Tomatoes", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 27, 28, 1, true, "White rice", 3, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 28, 50, 5, true, "Bread", 5, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 29, 35, 2, true, "Pasta", 7, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 30, 12, 3, true, "Milk", 8, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 31, 1, 20, true, "Cheese", 10, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 32, 4, 0, true, "Cucumber", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 33, 50, 0, true, "Mango", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 34, 50, 0, true, "Pineapple", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 35, 8, 0, true, "Strawberries", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 36, 14, 0, true, "Blueberries", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 37, 12, 0, true, "Oranges", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 38, 16, 0, true, "Grapes", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 39, 8, 0, true, "Watermelon", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 40, 82, 0, true, "Honey", 0, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 41, 68, 0, true, "Maple syrup", 0, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 42, 45, 30, true, "Chocolate", 5, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 43, 5, 0, true, "Cauliflower", 2, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 44, 3, 0, true, "Asparagus", 2, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 45, 4, 0, true, "Zucchini", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { 46, 3, 0, true, "Celery", 1, new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") }
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
                name: "IX_FoodItems_UserId",
                table: "FoodItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserId",
                table: "Meals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalStats_UserId",
                table: "PersonalStats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Portions_FoodItemId",
                table: "Portions",
                column: "FoodItemId");

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
                name: "FK_FoodItems_Users_UserId",
                table: "FoodItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Users_UserId",
                table: "Meals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "Portions");

            migrationBuilder.DropTable(
                name: "ExerciseTemplates");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PersonalStats");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
