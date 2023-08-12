using BuffMeUp.Backend.Controllers;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Tests;

[TestFixture]
public class AccountControllerTests
{
    private Mock<IAccountService> _accountServiceMock;
    private Mock<IRoleService> _roleServiceMock;
    private AccountController _controller;

    [SetUp]
    public void SetUp()
    {
        _accountServiceMock = new Mock<IAccountService>();
        _roleServiceMock = new Mock<IRoleService>();
        _controller = new AccountController(_accountServiceMock.Object, _roleServiceMock.Object);
    }

    [Test]
    public async Task SignUp_EmailTaken_ReturnsBadRequest()
    {
        // Arrange
        var newUser = new UserSignUpFormModel { Email = "test@test.com" };
        _accountServiceMock.Setup(s => s.IsEmailAvailableAsync(newUser.Email)).ReturnsAsync(false);

        // Act
        var result = await _controller.SignUp(newUser);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task SignUp_UsernameTaken_ReturnsBadRequest()
    {
        // Arrange
        var newUser = new UserSignUpFormModel { Email = "test@test.com", Username = "test" };
        _accountServiceMock.Setup(s => s.IsEmailAvailableAsync(newUser.Email)).ReturnsAsync(true);
        _accountServiceMock.Setup(s => s.IsUsernameAvailableAsync(newUser.Username)).ReturnsAsync(false);

        // Act
        var result = await _controller.SignUp(newUser);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task SignUp_ValidUser_ReturnsOk()
    {
        // Arrange
        var newUser = new UserSignUpFormModel { Email = "test@test.com", Username = "test" };
        _accountServiceMock.Setup(s => s.IsEmailAvailableAsync(newUser.Email)).ReturnsAsync(true);
        _accountServiceMock.Setup(s => s.IsUsernameAvailableAsync(newUser.Username)).ReturnsAsync(true);
        _accountServiceMock.Setup(s => s.RegisterUserAsync(newUser)).ReturnsAsync("token");

        // Act
        var result = await _controller.SignUp(newUser);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task LogIn_InvalidCredentials_ReturnsBadRequest()
    {
        // Arrange
        var user = new UserLogInFormModel { Username = "test", Password = "password" };
        _accountServiceMock.Setup(s => s.LogInUserAsync(user)).ReturnsAsync((string)null);

        // Act
        var result = await _controller.LogIn(user);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task LogIn_ValidCredentials_ReturnsOk()
    {
        // Arrange
        var user = new UserLogInFormModel { Username = "test", Password = "password" };
        _accountServiceMock.Setup(s => s.LogInUserAsync(user)).ReturnsAsync("token");

        // Act
        var result = await _controller.LogIn(user);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task GetAllUsers_NotAuthorized_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");

        // Act
        var result = await _controller.GetAllUsers();

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task GetAllUsers_Authorized_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "admin");
        _accountServiceMock.Setup(s => s.GetAllUsersAsync()).ReturnsAsync(new[] { new UserViewModel() });

        // Act
        var result = await _controller.GetAllUsers();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task GetUserAvatar_ValidUser_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        _accountServiceMock.Setup(s => s.GetAvatarAsync(It.IsAny<Guid>())).ReturnsAsync(new byte[0]);

        // Act
        var result = await _controller.GetUserAvatar();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task UpdateUserRole_InvalidRole_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext("admin", "admin");
        var model = new UserUpdateModel { Id = "user", Role = "invalid" };
        _roleServiceMock.Setup(s => s.IsValidRoleAsync(model.Role)).ReturnsAsync(false);

        // Act
        var result = await _controller.UpdateUserRole(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task UpdateUserRole_ValidRole_ReturnsOk()
    {
        // Arrange
        SetUserContext("admin", "admin");
        var model = new UserUpdateModel { Id = "user", Role = "valid" };
        _roleServiceMock.Setup(s => s.IsValidRoleAsync(model.Role)).ReturnsAsync(true);

        // Act
        var result = await _controller.UpdateUserRole(model);

        // Assert
        Assert.IsInstanceOf<OkResult>(result);
    }


    private void SetUserContext(string userId, string role)
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
             new Claim("userId", userId),
             new Claim("userRole", role)
        }, "mock"));

        _controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext() { User = user }
        };
    }
}
