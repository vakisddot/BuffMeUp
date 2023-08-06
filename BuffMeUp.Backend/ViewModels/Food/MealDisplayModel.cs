namespace BuffMeUp.Backend.ViewModels.Food;

public class MealDisplayModel
{
    public Guid Id { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Protein { get; set; }
    public int Fats { get; set; }
    public int Carbs { get; set; }
}
