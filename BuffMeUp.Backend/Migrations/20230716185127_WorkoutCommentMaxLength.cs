using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuffMeUp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutCommentMaxLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Workouts",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Comment",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

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
        }
    }
}
