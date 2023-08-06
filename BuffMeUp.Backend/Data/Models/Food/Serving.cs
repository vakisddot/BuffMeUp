using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuffMeUp.Backend.Data.Models.Food;

public class Serving
{
    [ForeignKey(nameof(Meal))]
    public Guid MealId { get; set; }
    public Meal Meal { get; set; } = null!;

    [ForeignKey(nameof(FoodItem))]
    public int FoodItemId { get; set; }
    public FoodItem FoodItem { get; set; } = null!;

    [Required]
    public int Grams { get; set; }
}
