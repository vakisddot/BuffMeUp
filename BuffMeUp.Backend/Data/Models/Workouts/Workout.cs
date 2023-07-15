using BuffMeUp.Backend.Data.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuffMeUp.Backend.Data.Models.Workouts;

public class Workout
{
    public Workout()
    {
        ExerciseSets = new HashSet<ExerciseSet>();
    }


    [Key]
    public Guid Id { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    public DateTime Date { get; set; }

    public string? Comment { get; set; }


    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public virtual ICollection<ExerciseSet> ExerciseSets { get; set; }
}
