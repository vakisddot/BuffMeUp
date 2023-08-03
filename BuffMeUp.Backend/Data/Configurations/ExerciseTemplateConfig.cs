using BuffMeUp.Backend.Data.Models.Workouts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuffMeUp.Backend.Data.Configurations;

public class ExerciseTemplateConfig : IEntityTypeConfiguration<ExerciseTemplate>
{
    public void Configure(EntityTypeBuilder<ExerciseTemplate> builder)
    {
        builder.Property(e => e.ExerciseType)
            .HasConversion<int>();

        builder.HasOne(e => e.User)
            .WithMany(u => u.ExerciseTemplates)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(GenerateExerciseTemplates());
    }

    ExerciseTemplate[] GenerateExerciseTemplates()
    {
        return new[]
        {
            new ExerciseTemplate
            {
                Name = "Bench Press",
                Description = "Lie on your back on a flat bench. Grip the bar with your hands slightly wider than shoulder-width apart. Lift the bar off the rack and position it above your chest with arms fully extended.",
                IsGlobal = true,
                ExerciseType = ExerciseType.Chest,
                UserId = ConfigUtils.AdminUserId,
            },
            new ExerciseTemplate
            {
                Name = "Deadlift",
                Description = "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.",
                IsGlobal = true,
                ExerciseType = ExerciseType.Back,
                UserId = ConfigUtils.AdminUserId,
            },
            new ExerciseTemplate
            {
                Name = "Squat",
                Description = "Stand with your mid-foot under the barbell. Bend over and grab the bar with a shoulder-width grip. Bend your knees until your shins touch the bar. Lift your chest up and straighten your lower back.",
                IsGlobal = true,
                ExerciseType = ExerciseType.Legs,

                UserId = ConfigUtils.AdminUserId,
            },
            new ExerciseTemplate
            {
                Name = "Overhead Press",
                Description = "Stand with the bar on your front shoulders, and your hands next to your shoulders. Press the bar over your head, until it’s balanced over your shoulders and mid-foot.",
                IsGlobal = true,
                ExerciseType = ExerciseType.Shoulders,

                UserId = ConfigUtils.AdminUserId,
            },
            new ExerciseTemplate
            {
                Name = "Pull-up",
                Description = "Grab the pull-up bar with your palms down (shoulder-width grip). Hang to the pull-up bar with straight arms and your legs off the floor. Pull yourself up by pulling your elbows down to the floor.",
                IsGlobal = true,
                ExerciseType = ExerciseType.Back,

                UserId = ConfigUtils.AdminUserId,    
            },
            new ExerciseTemplate
            {
                Name = "Dumbbell Curl",
                Description = "Stand up with your torso upright while holding a dumbbell on each hand being held at arms length. The elbows should be close to the torso. This will be your starting position.",
                IsGlobal = true,
                ExerciseType = ExerciseType.Biceps,

                UserId = ConfigUtils.AdminUserId,
            },
            new ExerciseTemplate
            {
                Name = "Triceps Pushdown",
                Description = "Attach a straight or angled bar to a high pulley and grab with an overhand grip at shoulder width. Standing upright with the torso straight and a very small inclination forward, bring the upper arms close to your body and perpendicular to the floor.",
                IsGlobal = true,
                ExerciseType = ExerciseType.Triceps,

                UserId = ConfigUtils.AdminUserId,
            },
            new ExerciseTemplate
            {
                Name = "Sit-up",
                Description = "Lie on your back on the floor. Bend your legs and place feet firmly on the ground to stabilize your lower body. Cross your hands to opposite shoulders or place them behind your ears, without pulling on your neck.",
                IsGlobal = true,
                ExerciseType = ExerciseType.Core,

                UserId = ConfigUtils.AdminUserId,
            }
        };
    }
}
