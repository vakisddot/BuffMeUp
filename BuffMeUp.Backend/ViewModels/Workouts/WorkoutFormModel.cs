namespace BuffMeUp.Backend.ViewModels.Workouts;

public class WorkoutFormModel
{
    public WorkoutFormModel()
    {
        ExerciseSetsIds = new List<Guid>();
    }

    public Guid Id { get; set; }
    public string? Comment { get; set; }
    public IEnumerable<Guid> ExerciseSetsIds { get; set; }
}
