using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuffMeUp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixedFoodEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JT_Meal_MealTemplate");

            migrationBuilder.DropTable(
                name: "JT_MealTemplate_FoodItem");

            migrationBuilder.DropTable(
                name: "MealTemplates");

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("0887ce69-b32f-49e4-b0a5-97931ced172a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("16bbd3fa-7d4b-43c1-b746-146405772e1e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("3c775b1c-aa82-44ff-8b72-55304281fecf"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("42cd3b95-542f-4bcf-8161-76f2ae6c962e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("71c4ca6b-c62a-4ab4-b846-1efb7f0cfb66"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("8f1069cd-3101-44d0-ac76-2734b301791e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("9f01b709-5241-4a33-94c0-30dcd9312067"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("beeb7017-bb27-4077-af05-df7941eebdd3"));

            migrationBuilder.AddColumn<int>(
                name: "Grams",
                table: "JT_Meal_FoodItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsGlobal",
                table: "FoodItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "FoodItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FoodItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "Description", "ExerciseType", "IsGlobal", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("4f511810-31bf-468a-9e12-13e940170755"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 0, true, "Deadlift", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("6edb1ba1-d1f7-4cae-93f2-be974cde3c6d"), "Stand up with your torso upright while holding a dumbbell on each hand being held at arms length. The elbows should be close to the torso. This will be your starting position.", 5, true, "Dumbbell Curl", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("77c4d84c-75d8-4bca-a085-804c4d198558"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 2, true, "Squat", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("a92c06e1-b086-44b4-a22d-78234de7abd1"), "Lie on your back on the floor. Bend your legs and place feet firmly on the ground to stabilize your lower body. Cross your hands to opposite shoulders or place them behind your ears, without pulling on your neck.", 6, true, "Sit-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("bd415227-4f70-4a0e-a1bd-45d1cddf77ef"), "Stand with the bar on your front shoulders, and your hands next to your shoulders. Press the bar over your head, until it’s balanced over your shoulders and mid-foot.", 3, true, "Overhead Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("c85c92f4-4656-48ae-893c-a0139a1e52a4"), "Attach a straight or angled bar to a high pulley and grab with an overhand grip at shoulder width. Standing upright with the torso straight and a very small inclination forward, bring the upper arms close to your body and perpendicular to the floor.", 4, true, "Triceps Pushdown", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("dd99a911-7651-4f9b-abed-a3439bd388aa"), "Lie on your back on a flat bench. Grip the bar with your hands slightly wider than shoulder-width apart. Lift the bar off the rack and position it above your chest with arms fully extended.", 1, true, "Bench Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("f6f8ec4a-374c-4633-9085-414d3f727df3"), "Grab the pull-up bar with your palms down (shoulder-width grip). Hang to the pull-up bar with straight arms and your legs off the floor. Pull yourself up by pulling your elbows down to the floor.", 0, true, "Pull-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"),
                column: "PasswordHash",
                value: "dSvBqZfF6CgrUwZPAVYALg==;AkaKg5ZLkcWQvNNfMD1avbWvGgp1RS00yfpZMvDANmY=");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_UserId",
                table: "FoodItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_Users_UserId",
                table: "FoodItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_Users_UserId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_UserId",
                table: "FoodItems");

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("4f511810-31bf-468a-9e12-13e940170755"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("6edb1ba1-d1f7-4cae-93f2-be974cde3c6d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("77c4d84c-75d8-4bca-a085-804c4d198558"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("a92c06e1-b086-44b4-a22d-78234de7abd1"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("bd415227-4f70-4a0e-a1bd-45d1cddf77ef"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c85c92f4-4656-48ae-893c-a0139a1e52a4"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("dd99a911-7651-4f9b-abed-a3439bd388aa"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("f6f8ec4a-374c-4633-9085-414d3f727df3"));

            migrationBuilder.DropColumn(
                name: "Grams",
                table: "JT_Meal_FoodItem");

            migrationBuilder.DropColumn(
                name: "IsGlobal",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FoodItems");

            migrationBuilder.CreateTable(
                name: "MealTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealTemplates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_JT_Meal_MealTemplate_MealTemplates_MealTemplateId",
                        column: x => x.MealTemplateId,
                        principalTable: "MealTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JT_Meal_MealTemplate_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_JT_MealTemplate_FoodItem_MealTemplates_MealId",
                        column: x => x.MealId,
                        principalTable: "MealTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "Description", "ExerciseType", "IsGlobal", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("0887ce69-b32f-49e4-b0a5-97931ced172a"), "Attach a straight or angled bar to a high pulley and grab with an overhand grip at shoulder width. Standing upright with the torso straight and a very small inclination forward, bring the upper arms close to your body and perpendicular to the floor.", 4, true, "Triceps Pushdown", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("16bbd3fa-7d4b-43c1-b746-146405772e1e"), "Grab the pull-up bar with your palms down (shoulder-width grip). Hang to the pull-up bar with straight arms and your legs off the floor. Pull yourself up by pulling your elbows down to the floor.", 0, true, "Pull-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("3c775b1c-aa82-44ff-8b72-55304281fecf"), "Lie on your back on the floor. Bend your legs and place feet firmly on the ground to stabilize your lower body. Cross your hands to opposite shoulders or place them behind your ears, without pulling on your neck.", 6, true, "Sit-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("42cd3b95-542f-4bcf-8161-76f2ae6c962e"), "Stand up with your torso upright while holding a dumbbell on each hand being held at arms length. The elbows should be close to the torso. This will be your starting position.", 5, true, "Dumbbell Curl", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("71c4ca6b-c62a-4ab4-b846-1efb7f0cfb66"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 2, true, "Squat", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("8f1069cd-3101-44d0-ac76-2734b301791e"), "Lie on your back on a flat bench. Grip the bar with your hands slightly wider than shoulder-width apart. Lift the bar off the rack and position it above your chest with arms fully extended.", 1, true, "Bench Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("9f01b709-5241-4a33-94c0-30dcd9312067"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 0, true, "Deadlift", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("beeb7017-bb27-4077-af05-df7941eebdd3"), "Stand with the bar on your front shoulders, and your hands next to your shoulders. Press the bar over your head, until it’s balanced over your shoulders and mid-foot.", 3, true, "Overhead Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"),
                column: "PasswordHash",
                value: "fZI/SHcSUMxTdC3pxzHDHw==;2akvr6O9/tS+G7QtrjgFwKgwMDbTWph1MXA+kMWq3lE=");

            migrationBuilder.CreateIndex(
                name: "IX_JT_Meal_MealTemplate_MealTemplateId",
                table: "JT_Meal_MealTemplate",
                column: "MealTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_JT_MealTemplate_FoodItem_FoodItemId",
                table: "JT_MealTemplate_FoodItem",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MealTemplates_UserId",
                table: "MealTemplates",
                column: "UserId");
        }
    }
}
