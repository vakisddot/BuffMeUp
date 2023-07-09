using BuffMeUp.Backend.Data.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BuffMeUp.Backend.Common.ValidationConstants.ForMeal;

namespace BuffMeUp.Backend.Data.Models.Food;

/// <summary>
/// Meal templates are the templates that the user has created. They can be either global (visible to everyone) or not.
/// </summary>
public class MealTemplate
{
    public MealTemplate()
    {
        Id = Guid.NewGuid();
        MealTemplate_FoodItem = new HashSet<JT_MealTemplate_FoodItem>();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    public bool IsGlobal { get; set; }


    public virtual ICollection<JT_MealTemplate_FoodItem> MealTemplate_FoodItem { get; set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
}
