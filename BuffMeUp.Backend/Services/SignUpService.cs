using BuffMeUp.Backend.Data;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;

namespace BuffMeUp.Backend.Services;

public class SignUpService : ISignUpService
{
    readonly BuffMeUpDbContext _dbContext;

    public SignUpService(BuffMeUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool IsEmailAvailable(string email) => !_dbContext.Users.Any(u => u.Email == email);

    public bool IsUsernameAvailable(string username) => !_dbContext.Users.Any(u => u.Username == username);

    public void RegisterUser(UserSignUpViewModel newUser)
    {
        Console.WriteLine("Successfuly registered!! :)))");
        Console.WriteLine("Username: " + newUser.Username);
        Console.WriteLine("First Name: " + newUser.FirstName);
        Console.WriteLine("PW: " + newUser.Password);
        Console.WriteLine("Email: " + newUser.Email);
    }
}

public class MockSignUpService : ISignUpService
{
    public bool IsEmailAvailable(string email) => true;

    public bool IsUsernameAvailable(string username) => username != "ThisIsTaken";

    public void RegisterUser(UserSignUpViewModel newUser)
    {
        Console.WriteLine("Successfuly registered!! :)))");
        Console.WriteLine("Username: " + newUser.Username);
        Console.WriteLine("First Name: " + newUser.FirstName);
        Console.WriteLine("PW: " + newUser.Password);
        Console.WriteLine("Email: " + newUser.Email);
    }
}
