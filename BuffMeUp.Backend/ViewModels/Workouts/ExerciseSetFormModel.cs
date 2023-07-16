using System.ComponentModel.DataAnnotations;
using static BuffMeUp.Backend.Common.ValidationConstants.ForExerciseSet;

namespace BuffMeUp.Backend.ViewModels.Workouts;

public class ExerciseSetFormModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [Range(RepsMinValue, RepsMaxValue)]
    public int Reps { get; set; }

    [Required]
    [Range(WeightMinValue, WeightMaxValue)]
    public int Weight { get; set; }

    public Guid ExerciseTemplateId { get; set; }
    public Guid WorkoutId { get; set; }
}
