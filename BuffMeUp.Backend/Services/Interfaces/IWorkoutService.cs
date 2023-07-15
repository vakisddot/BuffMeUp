using BuffMeUp.Backend.ViewModels.Workouts;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IWorkoutService
{
    Task StartNewWorkoutAsync(Guid userId);

    Task<IEnumerable<WorkoutSearchModel>> GetWorkoutsByPageAsync(int page, int resultCount, Guid userId);

    Task<WorkoutDisplayModel?> GetWorkoutDetailsAsync(Guid id);

    Task UpdateWorkoutAsync(WorkoutFormModel model);

    Task DeleteWorkoutAsync(Guid id);
}
