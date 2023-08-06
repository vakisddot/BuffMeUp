using System.ComponentModel.DataAnnotations;
using static BuffMeUp.Backend.Common.ValidationConstants.ForUser;

namespace BuffMeUp.Backend.ViewModels.Account;

public class UserSignUpFormModel
{
    [Required]
    [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
    [RegularExpression(UsernameRegex, ErrorMessage = UsernameRegexErrorMessage)]
    public string Username { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
    public string Password { get; set; } = null!;

    [Required]
    [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
    public string FirstName { get; set; } = null!;
}
