namespace BuffMeUp.Backend.ViewModels.Food;

public class PortionDisplayModel
{
    public Guid Id { get; set; }
    public int Grams { get; set; }
    public FoodItemDisplayModel FoodItem { get; set; } = null!;
}
