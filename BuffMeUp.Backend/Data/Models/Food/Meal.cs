using BuffMeUp.Backend.Data.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuffMeUp.Backend.Data.Models.Food;

/// <summary>
/// Meals are the actual meals that the user has eaten. They can be either from a template or not.
/// </summary>
public class Meal
{
    public Meal()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime Date { get; set; }


    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;


    [ForeignKey(nameof(FoodItem))]
    public int? FoodItemId { get; set; }
    public FoodItem? FoodItem { get; set; }    
    
    [ForeignKey(nameof(MealTemplate))]
    public Guid? MealTemplateId { get; set; }
    public MealTemplate? MealTemplate { get; set; }
}
