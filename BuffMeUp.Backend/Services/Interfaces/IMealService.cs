using BuffMeUp.Backend.ViewModels.Food;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IMealService
{
    Task<IEnumerable<MealDisplayModel>> GetMealsByDateAsync(DateTime date, Guid userId);

    Task AddNewMealAsync(Guid userId);

    Task DeleteMealAsync(Guid mealId);
}
