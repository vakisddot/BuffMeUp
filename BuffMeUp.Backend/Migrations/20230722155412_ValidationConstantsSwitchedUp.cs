using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuffMeUp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class ValidationConstantsSwitchedUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("0a6bf23e-5ce6-4f5a-a879-5f2ce0b25e94"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("112b60aa-74d4-4ddd-9913-f28e344ad24d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("70be9126-c4c6-4582-958a-7de49edcdfd1"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("71599532-e2e6-48ea-b086-480317ab434e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("94552614-6f7b-45c0-a584-b785f1fc7c4a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("989e5637-df0b-47df-9a5f-50b8dbf0e7f6"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("f5e40f1f-c2b8-47e2-b222-7bfa396e6f91"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("fd9c077c-2788-4c75-b8a8-4db7c3c1dc10"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExerciseTemplates",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExerciseTemplates",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)",
                oldMaxLength: 24);

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "Description", "ExerciseType", "IsGlobal", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("0a6bf23e-5ce6-4f5a-a879-5f2ce0b25e94"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 2, true, "Squat", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("112b60aa-74d4-4ddd-9913-f28e344ad24d"), "Lie on your back on a flat bench. Grip the bar with your hands slightly wider than shoulder-width apart. Lift the bar off the rack and position it above your chest with arms fully extended.", 1, true, "Bench Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("70be9126-c4c6-4582-958a-7de49edcdfd1"), "Lie on your back on the floor. Bend your legs and place feet firmly on the ground to stabilize your lower body. Cross your hands to opposite shoulders or place them behind your ears, without pulling on your neck.", 6, true, "Sit-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("71599532-e2e6-48ea-b086-480317ab434e"), "Attach a straight or angled bar to a high pulley and grab with an overhand grip at shoulder width. Standing upright with the torso straight and a very small inclination forward, bring the upper arms close to your body and perpendicular to the floor.", 4, true, "Triceps Pushdown", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("94552614-6f7b-45c0-a584-b785f1fc7c4a"), "Grab the pull-up bar with your palms down (shoulder-width grip). Hang to the pull-up bar with straight arms and your legs off the floor. Pull yourself up by pulling your elbows down to the floor.", 0, true, "Pull-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("989e5637-df0b-47df-9a5f-50b8dbf0e7f6"), "Stand up with your torso upright while holding a dumbbell on each hand being held at arms length. The elbows should be close to the torso. This will be your starting position.", 5, true, "Dumbbell Curl", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("f5e40f1f-c2b8-47e2-b222-7bfa396e6f91"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 0, true, "Deadlift", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("fd9c077c-2788-4c75-b8a8-4db7c3c1dc10"), "Stand with the bar on your front shoulders, and your hands next to your shoulders. Press the bar over your head, until it’s balanced over your shoulders and mid-foot.", 3, true, "Overhead Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"),
                column: "PasswordHash",
                value: "11EK0Ze+e8Do6GYPtmvujw==;i5hW8rHZ7jEM+79POR+hDZHkn5MpctdNVnHZbx2VKFA=");
        }
    }
}
