using System.ComponentModel.DataAnnotations;
using static BuffMeUp.Backend.Common.ValidationConstants.ForUser;

namespace BuffMeUp.Backend.ViewModels.Account;

public class UserLogInFormModel
{
    [Required]
    [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
    [RegularExpression(UsernameRegex, ErrorMessage = UsernameRegexErrorMessage)]
    public string Username { get; set; } = null!;

    [Required]
    [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
    public string Password { get; set; } = null!;
}
