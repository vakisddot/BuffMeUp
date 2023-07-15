namespace BuffMeUp.Backend.ViewModels.Workouts;

public class ExerciseSetFormModel
{
    public Guid Id { get; set; }
    public int Reps { get; set; }
    public int Weight { get; set; }
    public Guid ExerciseTemplateId { get; set; }
    public Guid WorkoutId { get; set; }
}
