using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuffMeUp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class FoodItemUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("0ff467b8-3513-4907-92dd-6daa75c900e5"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("484d6c42-5e62-4821-85ba-f528da3ac598"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("65a45f26-77ba-4aa5-aadf-340698a0dd91"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7423c92a-b60e-4439-b310-1ce945a07014"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("8eb38f00-f8fc-4a3c-8cc3-0d06ca8e0658"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("a04301d5-a004-4a84-95bf-5c72982bc9cc"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("cffceeee-840d-44b1-ba78-37f25c4808e5"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("ed30d261-c880-4a4c-a29d-ed858ac8cfab"));

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "FoodItems");

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "Description", "ExerciseType", "IsGlobal", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("2eb1043a-bbc1-4b33-a358-eb243c9ae063"), "Stand with the bar on your front shoulders, and your hands next to your shoulders. Press the bar over your head, until it’s balanced over your shoulders and mid-foot.", 3, true, "Overhead Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("4dba3512-77a3-40ce-8c79-44079b46b272"), "Grab the pull-up bar with your palms down (shoulder-width grip). Hang to the pull-up bar with straight arms and your legs off the floor. Pull yourself up by pulling your elbows down to the floor.", 0, true, "Pull-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("7437da1b-b399-47d5-83bb-016fb955e672"), "Attach a straight or angled bar to a high pulley and grab with an overhand grip at shoulder width. Standing upright with the torso straight and a very small inclination forward, bring the upper arms close to your body and perpendicular to the floor.", 4, true, "Triceps Pushdown", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("88a6bb9c-d8aa-46a1-b060-17be6463158d"), "Lie on your back on the floor. Bend your legs and place feet firmly on the ground to stabilize your lower body. Cross your hands to opposite shoulders or place them behind your ears, without pulling on your neck.", 6, true, "Sit-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("aad56ab1-ae8e-45f8-93aa-b6875bdff9d8"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 2, true, "Squat", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("aaed5dcc-5713-4271-ab08-cd877ffa96b5"), "Lie on your back on a flat bench. Grip the bar with your hands slightly wider than shoulder-width apart. Lift the bar off the rack and position it above your chest with arms fully extended.", 1, true, "Bench Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("c26cf98c-fc17-4910-b5da-1bf1ee9c1323"), "Stand up with your torso upright while holding a dumbbell on each hand being held at arms length. The elbows should be close to the torso. This will be your starting position.", 5, true, "Dumbbell Curl", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("fa302f3c-12ac-496e-8153-2258c315f233"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 0, true, "Deadlift", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") }
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"),
                column: "PasswordHash",
                value: "ZiKzgbLDLMPY18CjiryE8g==;v52m5NUMPUwznKd9EBUD44iJaOLcI5IwCio/MGsHaZg=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("2eb1043a-bbc1-4b33-a358-eb243c9ae063"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("4dba3512-77a3-40ce-8c79-44079b46b272"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("7437da1b-b399-47d5-83bb-016fb955e672"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("88a6bb9c-d8aa-46a1-b060-17be6463158d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("aad56ab1-ae8e-45f8-93aa-b6875bdff9d8"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("aaed5dcc-5713-4271-ab08-cd877ffa96b5"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("c26cf98c-fc17-4910-b5da-1bf1ee9c1323"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("fa302f3c-12ac-496e-8153-2258c315f233"));

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "FoodItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "Description", "ExerciseType", "IsGlobal", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("0ff467b8-3513-4907-92dd-6daa75c900e5"), "Lie on your back on the floor. Bend your legs and place feet firmly on the ground to stabilize your lower body. Cross your hands to opposite shoulders or place them behind your ears, without pulling on your neck.", 6, true, "Sit-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("484d6c42-5e62-4821-85ba-f528da3ac598"), "Attach a straight or angled bar to a high pulley and grab with an overhand grip at shoulder width. Standing upright with the torso straight and a very small inclination forward, bring the upper arms close to your body and perpendicular to the floor.", 4, true, "Triceps Pushdown", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("65a45f26-77ba-4aa5-aadf-340698a0dd91"), "Stand up with your torso upright while holding a dumbbell on each hand being held at arms length. The elbows should be close to the torso. This will be your starting position.", 5, true, "Dumbbell Curl", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("7423c92a-b60e-4439-b310-1ce945a07014"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 0, true, "Deadlift", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("8eb38f00-f8fc-4a3c-8cc3-0d06ca8e0658"), "Grab the pull-up bar with your palms down (shoulder-width grip). Hang to the pull-up bar with straight arms and your legs off the floor. Pull yourself up by pulling your elbows down to the floor.", 0, true, "Pull-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("a04301d5-a004-4a84-95bf-5c72982bc9cc"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 2, true, "Squat", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("cffceeee-840d-44b1-ba78-37f25c4808e5"), "Lie on your back on a flat bench. Grip the bar with your hands slightly wider than shoulder-width apart. Lift the bar off the rack and position it above your chest with arms fully extended.", 1, true, "Bench Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("ed30d261-c880-4a4c-a29d-ed858ac8cfab"), "Stand with the bar on your front shoulders, and your hands next to your shoulders. Press the bar over your head, until it’s balanced over your shoulders and mid-foot.", 3, true, "Overhead Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"),
                column: "PasswordHash",
                value: "sfiPd/gT97ljx77CmIkTKw==;oQ2wf8+BIkgm3fDwIYj0dl+355CkyuYeTPXuCCfugA4=");
        }
    }
}
