namespace BuffMeUp.Backend.ViewModels.Account;

public class UserViewModel
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public byte[]? Avatar { get; set; }
}
