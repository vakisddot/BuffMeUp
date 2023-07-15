namespace BuffMeUp.Backend.ViewModels.Workouts;

public class WorkoutDisplayModel
{
    public WorkoutDisplayModel()
    {
        Sets = new List<ExerciseSetDisplayModel>();
    }

    public Guid Id { get; set; }
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public string? Comment { get; set; }
    public IEnumerable<ExerciseSetDisplayModel> Sets { get; set; }
    public Guid UserId { get; set; }
}
