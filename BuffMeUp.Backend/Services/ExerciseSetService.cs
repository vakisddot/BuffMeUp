using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Data.Models.Workouts;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;

namespace BuffMeUp.Backend.Services;

public class ExerciseSetService : IExerciseSetService
{
    readonly BuffMeUpDbContext _dbContext;

    public ExerciseSetService(BuffMeUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateExerciseSetAsync(ExerciseSetFormModel model)
    {
        var exerciseSet = new ExerciseSet
        {
            Reps = model.Reps,
            Weight = model.Weight,
            ExerciseTemplateId = model.ExerciseTemplateId,
            WorkoutId = model.WorkoutId
        };

        await _dbContext.ExerciseSets.AddAsync(exerciseSet);
        await _dbContext.SaveChangesAsync();
    }
}
