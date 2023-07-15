namespace BuffMeUp.Backend.ViewModels.Workouts;

public class WorkoutSearchModel
{
    public WorkoutSearchModel()
    {
        Sets = new List<string>();
    }

    public Guid Id { get; set; }
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public string? Comment { get; set; }
    public IEnumerable<string> Sets { get; set; }
}