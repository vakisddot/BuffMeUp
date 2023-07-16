using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuffMeUp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseSetsNumbered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("2563d0c5-c76c-4980-b3bf-28778ac73f86"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("56e4a8c0-69ba-47a1-9cfb-6e41ef950f6a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("8163c55a-7716-4ce8-8440-54cab09ea35d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("b96bd616-1dc1-4543-891f-4fc659bfec96"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("cb374e7c-ff29-46c7-a646-7d4a0c6ae81e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("da5732ea-4e64-47a6-85c1-49a9f7261e86"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("e7f3286c-fa5b-499f-92bc-23ae8f58352d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTemplates",
                keyColumn: "Id",
                keyValue: new Guid("f527757f-9c9b-49ac-89d6-de2b67f75e86"));

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "ExerciseSets",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Number",
                table: "ExerciseSets");

            migrationBuilder.InsertData(
                table: "ExerciseTemplates",
                columns: new[] { "Id", "Description", "ExerciseType", "IsGlobal", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("2563d0c5-c76c-4980-b3bf-28778ac73f86"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 2, true, "Squat", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("56e4a8c0-69ba-47a1-9cfb-6e41ef950f6a"), "Lie on your back on the floor. Bend your legs and place feet firmly on the ground to stabilize your lower body. Cross your hands to opposite shoulders or place them behind your ears, without pulling on your neck.", 6, true, "Sit-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("8163c55a-7716-4ce8-8440-54cab09ea35d"), "Lie on your back on a flat bench. Grip the bar with your hands slightly wider than shoulder-width apart. Lift the bar off the rack and position it above your chest with arms fully extended.", 1, true, "Bench Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("b96bd616-1dc1-4543-891f-4fc659bfec96"), "Stand with the bar on your front shoulders, and your hands next to your shoulders. Press the bar over your head, until it’s balanced over your shoulders and mid-foot.", 3, true, "Overhead Press", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("cb374e7c-ff29-46c7-a646-7d4a0c6ae81e"), "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.", 0, true, "Deadlift", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("da5732ea-4e64-47a6-85c1-49a9f7261e86"), "Grab the pull-up bar with your palms down (shoulder-width grip). Hang to the pull-up bar with straight arms and your legs off the floor. Pull yourself up by pulling your elbows down to the floor.", 0, true, "Pull-up", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("e7f3286c-fa5b-499f-92bc-23ae8f58352d"), "Stand up with your torso upright while holding a dumbbell on each hand being held at arms length. The elbows should be close to the torso. This will be your starting position.", 5, true, "Dumbbell Curl", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") },
                    { new Guid("f527757f-9c9b-49ac-89d6-de2b67f75e86"), "Attach a straight or angled bar to a high pulley and grab with an overhand grip at shoulder width. Standing upright with the torso straight and a very small inclination forward, bring the upper arms close to your body and perpendicular to the floor.", 4, true, "Triceps Pushdown", new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1") }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41fc7ca7-c54c-4e7b-a68a-033f054b56d1"),
                column: "PasswordHash",
                value: "DIyfgQUqk1F8RGdvwGKYlg==;pplKG5BYL3YU3GEtkFNDAt6XPdk5H8yLjO3ZBge00ek=");
        }
    }
}
