using System.ComponentModel.DataAnnotations;
using static BuffMeUp.Backend.Common.ValidationConstants.ForExerciseSet;

namespace BuffMeUp.Backend.ViewModels.Workouts;

public class ExerciseSetUpdateModel
{
    [Required]
    [Range(RepsMinValue, RepsMaxValue)]
    public int Reps { get; set; }

    [Required]
    [Range(WeightMinValue, WeightMaxValue)]
    public int Weight { get; set; }

    [Required]
    public string ExerciseName { get; set; } = null!;

    public Guid WorkoutId { get; set; }
}
