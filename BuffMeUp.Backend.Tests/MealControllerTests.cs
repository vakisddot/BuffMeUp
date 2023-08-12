using BuffMeUp.Backend.Controllers.Food;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Food;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace BuffMeUp.Backend.Tests;

[TestFixture]
public class MealControllerTests
{
    private Mock<IMealService> _mealServiceMock;
    private MealController _controller;

    [SetUp]
    public void SetUp()
    {
        _mealServiceMock = new Mock<IMealService>();
        _controller = new MealController(_mealServiceMock.Object);
    }

    [Test]
    public async Task GetMealsByDay_InvalidDate_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");

        // Act
        var result = await _controller.GetMealsByDay("invalid");

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task GetMealsByDay_ValidDate_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var date = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        _mealServiceMock.Setup(s => s.GetMealsByDateAsync(It.IsAny<DateTime>(), It.IsAny<Guid>())).ReturnsAsync(new[] { new MealDisplayModel() });

        // Act
        var result = await _controller.GetMealsByDay(date);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task AddNewMeal_ValidUser_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");

        // Act
        var result = await _controller.AddNewMeal();

        // Assert
        Assert.IsInstanceOf<OkResult>(result);
    }

    [Test]
    public async Task DeleteMeal_InvalidMeal_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new MealDeleteModel { Id = Guid.NewGuid() };
        _mealServiceMock.Setup(s => s.MealIsByUserIdAsync(model.Id, It.IsAny<Guid>())).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteMeal(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task DeleteMeal_ValidMeal_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new MealDeleteModel { Id = Guid.NewGuid() };
        _mealServiceMock.Setup(s => s.MealIsByUserIdAsync(model.Id, It.IsAny<Guid>())).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteMeal(model);

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
