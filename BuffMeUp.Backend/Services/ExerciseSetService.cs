using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Data.Models.Auth;
using BuffMeUp.Backend.Data.Models.Workouts;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.EntityFrameworkCore;

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
        var sets = await GetExerciseSetsAsync(model.WorkoutId, true);
        var latestSet = sets?.FirstOrDefault();

        int number = latestSet?.Number + 1 ?? 1;

        var exerciseSet = new ExerciseSet
        {
            Reps = model.Reps,
            Weight = model.Weight,
            Number = number,
            ExerciseTemplateId = model.ExerciseTemplateId,
            WorkoutId = model.WorkoutId
        };

        await _dbContext.ExerciseSets.AddAsync(exerciseSet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ExerciseSetDisplayModel>> GetExerciseSetsAsync(Guid workoutId, bool onlyGetFirst = false)
    {
        var sets = await _dbContext.ExerciseSets
            .Include(s => s.ExerciseTemplate)
            .Where(s => s.WorkoutId == workoutId)
            .OrderByDescending(s => s.Number)
            .Select(s => new ExerciseSetDisplayModel
            {
                Id = s.Id,
                Reps = s.Reps,
                Weight = s.Weight,
                Number = s.Number,
                ExerciseName = s.ExerciseTemplate.Name,
                ExerciseDescription = s.ExerciseTemplate.Description,
                ExerciseType = s.ExerciseTemplate.ExerciseType.ToString(),
            })
            .ToListAsync();

        return onlyGetFirst ? sets.Take(1) : sets;
    }
}
