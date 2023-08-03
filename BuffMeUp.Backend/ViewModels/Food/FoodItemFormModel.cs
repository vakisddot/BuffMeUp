using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.ViewModels.Food;

public class FoodItemFormModel
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int Protein { get; set; }

    [Required]
    public int Carbs { get; set; }

    [Required]
    public int Fats { get; set; }

    [Required]
    public bool IsGlobal { get; set; }
}
