using BuffMeUp.Backend.ViewModels.Food;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IServingService
{
    Task<IEnumerable<ServingDisplayModel>> GetServingsByMealIdAsync(Guid mealId);

    Task DeleteServingAsync(Guid mealId, int foodItemId);
}
