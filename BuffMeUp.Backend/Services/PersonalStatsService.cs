using BuffMeUp.Backend.Data;
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

    public async Task<PersonalStatsViewModel?> GetPersonalStatsAsync(Guid userId)
    {
        var stats = await _dbContext.PersonalStats.FirstOrDefaultAsync(u => u.UserId == userId);

        if (stats == null)
        {
            return null;
        }

        return new PersonalStatsViewModel
        {
            Age = stats.Age,
            Gender = stats.Gender,
            Height = stats.Height,
            StartingWeight = stats.StartingWeight,
            CurrentWeight = stats.CurrentWeight,
            GoalWeight = stats.GoalWeight,
        };
    }
}
