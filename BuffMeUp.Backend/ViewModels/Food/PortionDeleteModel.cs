using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.ViewModels.Food;

public class PortionDeleteModel
{
    [Required]
    public Guid Id { get; set; }
}
