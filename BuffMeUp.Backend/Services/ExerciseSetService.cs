using BuffMeUp.Backend.Data;
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

    public async Task<Guid> CreateExerciseSetAsync(ExerciseSetFormModel model)
    {
        var sets = await GetExerciseSetsByWorkoutIdAsync(model.WorkoutId, true);
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

        return exerciseSet.Id;
    }

    public async Task DeleteExerciseSetAsync(Guid id)
    {
        var exerciseSet = await _dbContext.ExerciseSets.FindAsync(id);

        if (exerciseSet == null)
        {
            return;
        }

        _dbContext.ExerciseSets.Remove(exerciseSet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ExerciseSetDisplayModel?> GetExerciseSetByIdAsync(Guid id)
    {
        var exerciseSet = await _dbContext.ExerciseSets
            .Include(s => s.ExerciseTemplate)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (exerciseSet == null)
        {
            return null;
        }

        return new ExerciseSetDisplayModel
        {
            Id = exerciseSet.Id,
            Reps = exerciseSet.Reps,
            Weight = exerciseSet.Weight,
            Number = exerciseSet.Number,
            ExerciseName = exerciseSet.ExerciseTemplate.Name,
            ExerciseDescription = exerciseSet.ExerciseTemplate.Description,
            ExerciseType = exerciseSet.ExerciseTemplate.ExerciseType.ToString(),
        };
    }

    public async Task<IEnumerable<ExerciseSetDisplayModel>> GetExerciseSetsByWorkoutIdAsync(Guid workoutId, bool onlyGetFirst = false)
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

    public async Task UpdateExerciseSetAsync(ExerciseSetFormModel model)
    {
        var exerciseSet = await _dbContext.ExerciseSets.FindAsync(model.Id);

        if (exerciseSet == null)
        {
            return;
        }

        exerciseSet.Reps = model.Reps;
        exerciseSet.Weight = model.Weight;

        await _dbContext.SaveChangesAsync();
    }
}
