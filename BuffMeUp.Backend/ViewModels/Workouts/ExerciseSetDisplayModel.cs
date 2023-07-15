namespace BuffMeUp.Backend.ViewModels.Workouts;

public class ExerciseSetDisplayModel
{
    public Guid Id { get; set; }
    public int Reps { get; set; }
    public int Weight { get; set; }
    public string ExerciseName { get; set; } = null!;
    public string? ExerciseDescription { get; set; }
    public string ExerciseType { get; set; } = null!;
}