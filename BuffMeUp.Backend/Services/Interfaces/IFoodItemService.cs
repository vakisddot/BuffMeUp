using BuffMeUp.Backend.ViewModels.Food;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IFoodItemService
{
    Task AddNewFoodItemAsync(FoodItemFormModel model, Guid userId);
}
