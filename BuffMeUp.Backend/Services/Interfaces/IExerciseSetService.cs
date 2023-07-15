using BuffMeUp.Backend.ViewModels.Workouts;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IExerciseSetService
{
    Task CreateExerciseSetAsync(ExerciseSetFormModel model);

    //Task<IEnumerable<ExerciseSetDisplayModel>> GetExerciseSetsAsync(int workoutId);

    //Task UpdateExerciseSetAsync(ExerciseSetFormModel model);

    //Task DeleteExerciseSetAsync(Guid id);
}
