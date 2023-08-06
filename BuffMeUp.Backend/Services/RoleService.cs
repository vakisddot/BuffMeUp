using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Data.Models.Account;
using BuffMeUp.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BuffMeUp.Backend.Services;

public class RoleService : IRoleService
{
    readonly BuffMeUpDbContext _dbContext;

    public RoleService(BuffMeUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsValidRoleAsync(string roleName)
    {
        return await _dbContext.Roles.AnyAsync(r => r.Name == roleName);
    }
}
