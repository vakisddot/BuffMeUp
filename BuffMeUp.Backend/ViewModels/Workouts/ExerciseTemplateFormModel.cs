namespace BuffMeUp.Backend.ViewModels.Workouts;

using System.ComponentModel.DataAnnotations;
using static BuffMeUp.Backend.Common.ValidationConstants.ForExerciseTemplate;

public class ExerciseTemplateFormModel
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    [StringLength(DescriptionMaxLength)]
    public string? Description { get; set; }
    public int ExerciseType { get; set; }
    public bool IsGlobal { get; set; }
}
