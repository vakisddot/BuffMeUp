using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Data.Models.Food;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Food;
using Microsoft.EntityFrameworkCore;

namespace BuffMeUp.Backend.Services;

public class PortionService : IPortionService
{
    readonly BuffMeUpDbContext _dbContext;

    public PortionService(BuffMeUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> CreatePortionAsync(PortionFormModel model)
    {
        var portion = new Portion
        {
            MealId = model.MealId,
            FoodItemId = model.FoodItemId,
            Grams = model.Grams,
        };

        await _dbContext.Portions.AddAsync(portion);
        await _dbContext.SaveChangesAsync();

        return portion.Id;
    }

    public async Task DeletePortionAsync(Guid id)
    {
        var serving = await _dbContext.Portions
            .FirstOrDefaultAsync(s => s.Id == id);

        if (serving == null) return;

        _dbContext.Portions.Remove(serving);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<PortionDisplayModel>> GetPortionsByMealIdAsync(Guid mealId)
    {
        var servings = await _dbContext.Portions
            .Include(s => s.FoodItem)
            .Where(s => s.MealId == mealId)
            .Select(s => new PortionDisplayModel
            {
                Id = s.Id,
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
