using BuffMeUp.Backend.Core;
using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Data.Models.Auth;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuffMeUp.Backend.Services;

public class AccountService : IAccountService
{
    readonly BuffMeUpDbContext _dbContext;
    readonly IConfiguration _config;

    public AccountService(BuffMeUpDbContext dbContext, IConfiguration config)
    {
        _dbContext = dbContext;
        _config = config;
    }

    public async Task<bool> IsEmailAvailableAsync(string email) 
        => !await _dbContext.Users.AnyAsync(u => u.Email == email);

    public async Task<bool> IsUsernameAvailableAsync(string username) 
        => !await _dbContext.Users.AnyAsync(u => u.Username == username);

    public async Task<string> RegisterUserAsync(UserSignUpFormModel newUser)
    {
        var user = new User
        {
            Username = newUser.Username,
            Email = newUser.Email,
            FirstName = newUser.FirstName,
            PasswordHash = PasswordHasher.HashPassword(newUser.Password),
        };

        var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
        user.Role = role!;

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return GenerateToken(user);
    }

    public async Task<string?> LogInUserAsync(UserLogInFormModel user)
    {
        var userFromDb = await _dbContext.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Username == user.Username);

        if (userFromDb == null)
        {
            return null;
        }

        if (PasswordHasher.VerifyPassword(userFromDb.PasswordHash, user.Password))
        {
            return GenerateToken(userFromDb);
        }

        return null;
    }

    string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("username", user.Username),
            new Claim("firstName", user.FirstName),
            new Claim("role", user.Role.Name)
        };

        var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
            _config["JwtSettings:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}