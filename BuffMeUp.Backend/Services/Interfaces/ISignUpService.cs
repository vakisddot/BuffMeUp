using BuffMeUp.Backend.ViewModels;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface ISignUpService
{
    bool IsUsernameAvailable(string username);

    bool IsEmailAvailable(string email);

    void RegisterUser(UserSignUpViewModel newUser);
}