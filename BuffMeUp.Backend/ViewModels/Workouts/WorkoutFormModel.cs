using System.ComponentModel.DataAnnotations;
using static BuffMeUp.Backend.Common.ValidationConstants.ForWorkout;

namespace BuffMeUp.Backend.ViewModels.Workouts;

public class WorkoutFormModel
{
    public WorkoutFormModel()
    {
        ExerciseSetsIds = new List<Guid>();
    }

    public Guid Id { get; set; }

    [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
    public string? Comment { get; set; }

    public IEnumerable<Guid> ExerciseSetsIds { get; set; }
}
