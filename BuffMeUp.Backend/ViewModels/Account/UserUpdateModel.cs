using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.ViewModels.Account;

public class UserUpdateModel
{
    [Required]
    public string Id { get; set; } = null!;

    [Required]
    public string Role { get; set; } = null!;
}
