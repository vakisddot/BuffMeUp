using BuffMeUp.Backend.ViewModels;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IAccountService
{
    Task<bool> IsUsernameAvailableAsync(string username);

    Task<bool> IsEmailAvailableAsync(string email);

    Task<string> RegisterUserAsync(UserSignUpFormModel newUser);

    Task<string?> LogInUserAsync(UserLogInFormModel user);
}