using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Food;
using Microsoft.EntityFrameworkCore;

namespace BuffMeUp.Backend.Services;

public class ServingService : IServingService
{
    readonly BuffMeUpDbContext _dbContext;

    public ServingService(BuffMeUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteServingAsync(Guid mealId, int foodItemId)
    {
        var serving = await _dbContext.Servings
            .FirstOrDefaultAsync(s => s.MealId == mealId && s.FoodItemId == foodItemId);

        if (serving == null) return;

        _dbContext.Servings.Remove(serving);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ServingDisplayModel>> GetServingsByMealIdAsync(Guid mealId)
    {
        var servings = await _dbContext.Servings
            .Include(s => s.FoodItem)
            .Where(s => s.MealId == mealId)
            .Select(s => new ServingDisplayModel
            {
                FoodItem = new FoodItemDisplayModel
                {
                    Id = s.FoodItemId,
                    Name = s.FoodItem.Name,
                    Protein = s.FoodItem.Protein,
                    Fats = s.FoodItem.Fats,
                    Carbs = s.FoodItem.Carbs,
                },
                Grams = s.Grams,
            })
            .ToListAsync();

        return servings;
    }
}
