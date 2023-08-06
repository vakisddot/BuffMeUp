using System.ComponentModel.DataAnnotations;

namespace BuffMeUp.Backend.ViewModels.Account;

public class AccountDeleteModel
{
    [Required]
    public string Id { get; set; } = null!;
}
