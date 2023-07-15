using System.ComponentModel.DataAnnotations.Schema;

namespace BuffMeUp.Backend.Data.Models.Food;

public class JT_Meal_MealTemplate
{
    [ForeignKey(nameof(Meal))]
    public Guid MealId { get; set; }
    public virtual Meal Meal { get; set; } = null!;

    [ForeignKey(nameof(MealTemplate))]
    public Guid MealTemplateId { get; set; }
    public virtual MealTemplate MealTemplate { get; set; } = null!;
}
