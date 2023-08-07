using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.ViewModels.Food;

public class PortionFormModel
{
    [Required]
    public Guid MealId { get; set; }

    [Required]
    public int FoodItemId { get; set; }

    [Required]
    public int Grams { get; set; }
}
