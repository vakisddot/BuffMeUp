using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Data.Models;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BuffMeUp.Backend.Services;

public class PersonalStatsService : IPersonalStatsService
{
    BuffMeUpDbContext _dbContext;

    public PersonalStatsService(BuffMeUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreatePersonalStatsAsync(PersonalStatsFormModel model, Guid userId)
    {
        var stats = new PersonalStats
        {
            Age = model.Age,
            Gender = model.Gender,
            Height = model.Height,
            StartingWeight = model.Weight,
            CurrentWeight = model.Weight,
            GoalWeight = model.GoalWeight,
            UserId = userId,
        };

        await _dbContext.PersonalStats.AddAsync(stats);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PersonalStatsDisplayModel?> GetPersonalStatsAsync(Guid userId)
    {
        var stats = await _dbContext.PersonalStats.FirstOrDefaultAsync(u => u.UserId == userId);

        if (stats == null)
        {
            return null;
        }

        return new PersonalStatsDisplayModel
        {
            Age = stats.Age,
            Gender = stats.Gender,
            Height = stats.Height,
            StartingWeight = stats.StartingWeight,
            CurrentWeight = stats.CurrentWeight,
            GoalWeight = stats.GoalWeight,
        };
    }

    public async Task<bool> PersonalStatsExistAsync(Guid userId)
    {
        return await _dbContext.PersonalStats.AnyAsync(u => u.UserId == userId);
    }

    public async Task UpdateStatsAsync(PersonalStatsFormModel model, Guid userId)
    {
        var stats = await _dbContext.PersonalStats.FirstOrDefaultAsync(u => u.UserId == userId);

        if (stats == null)
        {
            return;
        }

        stats.Age = model.Age;
        stats.Gender = model.Gender;
        stats.Height = model.Height;
        stats.CurrentWeight = model.Weight;
        stats.GoalWeight = model.GoalWeight;

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateWeightAsync(int newWeight, Guid userId)
    {
        var stats = await _dbContext.PersonalStats.FirstOrDefaultAsync(u => u.UserId == userId);

        if (stats == null)
        {
            return;
        }

        stats.CurrentWeight = newWeight;

        await _dbContext.SaveChangesAsync();
    }
}
