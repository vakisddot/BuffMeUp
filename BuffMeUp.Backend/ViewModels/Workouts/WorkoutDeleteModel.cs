using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.ViewModels.Workouts;

public class WorkoutDeleteModel
{
    [Required]
    public Guid Id { get; set; }
}
