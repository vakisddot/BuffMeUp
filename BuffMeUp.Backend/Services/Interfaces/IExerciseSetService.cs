using BuffMeUp.Backend.ViewModels.Workouts;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IExerciseSetService
{
    Task<Guid> CreateExerciseSetAsync(ExerciseSetFormModel model);

    Task<IEnumerable<ExerciseSetDisplayModel>> GetExerciseSetsByWorkoutIdAsync(Guid workoutId, bool onlyGetFirst = false);

    Task<ExerciseSetDisplayModel?> GetExerciseSetByIdAsync(Guid id);

    Task UpdateExerciseSetAsync(ExerciseSetFormModel model);

    Task DeleteExerciseSetAsync(Guid id);
}
