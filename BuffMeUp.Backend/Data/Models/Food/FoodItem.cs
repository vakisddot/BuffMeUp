using System.ComponentModel.DataAnnotations;
using static BuffMeUp.Backend.Common.ValidationConstants.ForFoodItem;

namespace BuffMeUp.Backend.Data.Models.Food;

/// <summary>
/// FoodItems are the building blocks of MealTemplates.
/// </summary>
public class FoodItem
{
    public FoodItem()
    {
        MealTemplate_FoodItemm = new HashSet<JT_MealTemplate_FoodItem>();
    }


    [Key]
    public int Id { get; set; }


    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(ProteinMinValue, ProteinMaxValue)]
    public int Protein { get; set; }

    [Required]
    [Range(CarbsMinValue, CarbsMaxValue)]
    public int Carbs { get; set; }

    [Required]
    [Range(FatsMinValue, FatsMaxValue)]
    public int Fats { get; set; }


    public virtual ICollection<JT_MealTemplate_FoodItem> MealTemplate_FoodItemm { get; set; }
}
