namespace BuffMeUp.Backend.Services.Interfaces;

public interface IRoleService
{
    Task<bool> IsValidRoleAsync(string roleName);
}
