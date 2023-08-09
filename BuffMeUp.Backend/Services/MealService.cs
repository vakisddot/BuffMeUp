using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Data.Models.Food;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Food;
using Microsoft.EntityFrameworkCore;

namespace BuffMeUp.Backend.Services;

public class MealService : IMealService
{
    readonly BuffMeUpDbContext _dbContext;

    public MealService(BuffMeUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<MealDisplayModel>> GetMealsByDateAsync(DateTime date, Guid userId)
    {
        var meals = await _dbContext.Meals
            .Include(m => m.Portions)
            .Where(m => 
                m.UserId == userId &&
                m.Date.Year == date.Year && 
                m.Date.Month == date.Month && 
                m.Date.Day == date.Day)
            .Select(m => new MealDisplayModel
            {
                Id = m.Id,
                Hour = m.Date.Hour,
                Minute = m.Date.Minute,
                Protein = m.Portions.ToList().Select(s => (int)Math.Round(s.FoodItem.Protein * s.Grams / 100f)).Sum(),
                Fats = m.Portions.ToList().Select(s => (int)Math.Round(s.FoodItem.Fats * s.Grams / 100f)).Sum(),
                Carbs = m.Portions.ToList().Select(s => (int)Math.Round(s.FoodItem.Carbs * s.Grams / 100f)).Sum()
            })
            .ToListAsync();

        return meals;
    }

    public async Task AddNewMealAsync(Guid userId)
    {
        var meal = new Meal
        {
            UserId = userId,
            Date = DateTime.Now,
        };

        await _dbContext.Meals.AddAsync(meal);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteMealAsync(Guid mealId)
    {
        var meal = await _dbContext.Meals.FirstOrDefaultAsync(m => m.Id == mealId);

        if (meal == null) return;

        _dbContext.Remove(meal);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> MealIsByUserIdAsync(Guid id)
    {
        return await _dbContext.Meals.AnyAsync(m => m.Id == id);
    }

    public async Task<bool> MealIsByUserIdAsync(Guid mealId, Guid userId)
    {
        var meal = await _dbContext.Meals.FirstOrDefaultAsync(m => m.Id == mealId);

        return meal != null && meal.UserId == userId;
    }
}
