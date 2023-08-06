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
            .Include(m => m.Servings)
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
                Protein = m.Servings.ToList().Select(s => s.FoodItem.Protein * (s.Grams / 100)).Sum(),
                Fats = m.Servings.ToList().Select(s => s.FoodItem.Fats * (s.Grams / 100)).Sum(),
                Carbs = m.Servings.ToList().Select(s => s.FoodItem.Carbs * (s.Grams / 100)).Sum()
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
        var meal = _dbContext.Meals.FirstOrDefaultAsync(m => m.Id == mealId);

        if (meal == null) return;

        _dbContext.Remove(meal);
        await _dbContext.SaveChangesAsync();
    }
}
