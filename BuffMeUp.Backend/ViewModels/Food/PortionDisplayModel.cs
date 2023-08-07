namespace BuffMeUp.Backend.ViewModels.Food;

public class PortionDisplayModel
{
    public int Grams { get; set; }
    public FoodItemDisplayModel FoodItem { get; set; } = null!;
}
