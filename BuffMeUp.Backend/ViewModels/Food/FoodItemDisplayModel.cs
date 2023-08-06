namespace BuffMeUp.Backend.ViewModels.Food;

public class FoodItemDisplayModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Protein { get; set; }
    public int Fats { get; set; }
    public int Carbs { get; set; }
}
