namespace BuffMeUp.Backend.ViewModels.Workouts;

public class ExerciseTemplateDisplayModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string ExerciseType { get; set; } = null!;
    public string SubmittedBy { get; set; } = null!;
}
