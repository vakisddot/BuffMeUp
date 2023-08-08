using BuffMeUp.Backend.ViewModels.Food;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IFoodItemService
{
    Task AddNewFoodItemAsync(FoodItemFormModel model, Guid userId);

    Task<IEnumerable<FoodItemDisplayModel>> GetFoodItemsAsync(Guid userId, string query);

    Task<bool> FoodItemExistsByIdAsync(int id);

    Task<bool> FoodItemExistsByNameAsync(string name);
}
