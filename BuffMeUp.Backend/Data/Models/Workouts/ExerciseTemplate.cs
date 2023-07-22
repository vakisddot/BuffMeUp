using BuffMeUp.Backend.Data.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BuffMeUp.Backend.Common.ValidationConstants.ForExerciseTemplate;

namespace BuffMeUp.Backend.Data.Models.Workouts;

public class ExerciseTemplate
{
    public ExerciseTemplate()
    {
        Id = Guid.NewGuid();
    }


    [Key]
    public Guid Id { get; set; }


    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    [StringLength(DescriptionMaxLength)]
    public string? Description { get; set; }

    [Required]
    public ExerciseType ExerciseType { get; set; }

    [Required]
    public bool IsGlobal { get; set; }


    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
}
