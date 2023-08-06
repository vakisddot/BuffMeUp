using BuffMeUp.Backend.ViewModels.Account;

namespace BuffMeUp.Backend.Services.Interfaces;

public interface IAccountService
{
    Task<bool> IsUsernameAvailableAsync(string username);

    Task<bool> IsEmailAvailableAsync(string email);

    Task<string> RegisterUserAsync(UserSignUpFormModel newUser);

    Task<string?> LogInUserAsync(UserLogInFormModel user);

    Task<IEnumerable<UserViewModel>> GetAllUsersAsync();

    Task UpdateUserRoleAsync(Guid userId, string roleName);

    Task DeleteUserAsync(Guid userId);

    Task<bool> IsAdminAccountAsync(Guid userId);

    bool IsOGAdmin(Guid userId);

    Task AddAvatarAsync(Guid userId, byte[] avatar);

    Task<byte[]?> GetAvatarAsync(Guid userId);
}