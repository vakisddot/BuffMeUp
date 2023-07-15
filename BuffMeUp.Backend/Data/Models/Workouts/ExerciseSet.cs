using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BuffMeUp.Backend.Common.ValidationConstants.ForExerciseSet;

namespace BuffMeUp.Backend.Data.Models.Workouts;

/// <summary>
/// Represents a set of an exercise.
/// </summary>
public class ExerciseSet
{
    public ExerciseSet()
    {
        Id = Guid.NewGuid();
    }


    [Key]
    public Guid Id { get; set; }


    [Required]
    [Range(RepsMinValue, RepsMaxValue)]
    public int Reps { get; set; }

    [Required]
    [Range(WeightMinValue, WeightMaxValue)]
    public int Weight { get; set; }


    [ForeignKey(nameof(ExerciseTemplate))]
    public Guid ExerciseTemplateId { get; set; }
    public ExerciseTemplate ExerciseTemplate { get; set; } = null!;


    [ForeignKey(nameof(Workout))]
    public Guid WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;
}
