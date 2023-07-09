using BuffMeUp.Backend.Data.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuffMeUp.Backend.Data.Models.Exercises;

public class Workout
{
    public Workout()
    {
        Id = Guid.NewGuid();
        Exercises = new HashSet<ExerciseSet>();
    }


    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime Date { get; set; }


    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public virtual ICollection<ExerciseSet> Exercises { get; set; }
}
