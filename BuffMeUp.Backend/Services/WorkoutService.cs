using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Data.Models.Workouts;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.EntityFrameworkCore;

namespace BuffMeUp.Backend.Services;

public class WorkoutService : IWorkoutService
{
    readonly BuffMeUpDbContext _dbContext;

    public WorkoutService(BuffMeUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task StartNewWorkoutAsync(Guid userId)
    {
        var latestWorkout = await GetWorkoutsByPageAsync(1, 1, userId);

        int number = latestWorkout.FirstOrDefault()?.Number + 1 ?? 1;

        var workout = new Workout
        {
            Number = number,
            Date = DateTime.UtcNow,
            UserId = userId,
        };

        await _dbContext.Workouts.AddAsync(workout);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<WorkoutSearchModel>> GetWorkoutsByPageAsync(int page, int resultCount, Guid userId)
    {
        var workouts = await _dbContext.Workouts
            .Where(w => w.UserId == userId)
            .OrderByDescending(w => w.Date)
            .Skip((page - 1) * resultCount)
            .Take(resultCount)
            .Select(w => new WorkoutSearchModel
            {
                Id = w.Id,
                Number = w.Number,
                Date = w.Date,
                Comment = w.Comment,
                Sets = w.ExerciseSets.Select(s => s.ExerciseTemplate.ExerciseType.ToString()),
            })
            .ToListAsync();

        return workouts;
    }

    public async Task UpdateWorkoutAsync(WorkoutFormModel model)
    {
        var workout = await _dbContext.Workouts
            .FirstOrDefaultAsync(w => w.Id == model.Id);

        if (workout == null)
        {
            return;
        }

        workout.Comment = model.Comment;

        await _dbContext.SaveChangesAsync();
    }

    public async Task<WorkoutDisplayModel?> GetWorkoutDetailsAsync(Guid id)
    {
        var workout = await _dbContext.Workouts
            .Include(w => w.ExerciseSets)
            .ThenInclude(s => s.ExerciseTemplate)
            .FirstOrDefaultAsync(w => w.Id == id);

        if (workout == null)
        {
            return null;
        }

        return new WorkoutDisplayModel
        {
            Id = workout.Id,
            Number = workout.Number,
            Date = workout.Date,
            Comment = workout.Comment,
            UserId = workout.UserId,
            Sets = workout.ExerciseSets.Select(set =>
            {
                return new ExerciseSetDisplayModel
                {
                    Id = set.Id,
                    Reps = set.Reps,
                    Weight = set.Weight,
                    ExerciseName = set.ExerciseTemplate.Name,
                    ExerciseDescription = set.ExerciseTemplate.Description,
                    ExerciseType = set.ExerciseTemplate.ExerciseType.ToString(),
                };
            })
        };
    }

    public async Task DeleteWorkoutAsync(Guid id)
    {
        var workout = await _dbContext.Workouts
            .FirstOrDefaultAsync(w => w.Id == id);

        if (workout == null)
        {
            return;
        }

        _dbContext.Workouts.Remove(workout);
        await _dbContext.SaveChangesAsync();
    }
}
