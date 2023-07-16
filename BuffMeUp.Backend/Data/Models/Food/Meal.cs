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
        Meal_FoodItem = new HashSet<JT_Meal_FoodItem>();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime Date { get; set; }


    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public virtual ICollection<JT_Meal_FoodItem> Meal_FoodItem { get; set; }
}
