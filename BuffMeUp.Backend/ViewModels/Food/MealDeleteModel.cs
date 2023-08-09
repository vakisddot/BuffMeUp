using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.ViewModels.Food;

public class MealDeleteModel
{
    [Required]
    public Guid Id { get; set; }
}
