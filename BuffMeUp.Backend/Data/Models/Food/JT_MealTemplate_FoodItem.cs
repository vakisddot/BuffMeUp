using System.ComponentModel.DataAnnotations.Schema;

namespace BuffMeUp.Backend.Data.Models.Food;

public class JT_MealTemplate_FoodItem
{
    [ForeignKey(nameof(Meal))]
    public Guid MealId { get; set; }

    public virtual MealTemplate Meal { get; set; } = null!;

    [ForeignKey(nameof(FoodItem))]
    public int FoodItemId { get; set; }

    public virtual FoodItem FoodItem { get; set; } = null!;
}
