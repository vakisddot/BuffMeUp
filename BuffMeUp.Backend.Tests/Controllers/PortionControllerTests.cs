using BuffMeUp.Backend.Controllers.Food;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Food;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Tests.Controllers;

[TestFixture]
public class PortionControllerTests
{
    private Mock<IPortionService> _portionServiceMock;
    private Mock<IMealService> _mealServiceMock;
    private Mock<IFoodItemService> _foodItemServiceMock;
    private PortionController _controller;

    [SetUp]
    public void SetUp()
    {
        _portionServiceMock = new Mock<IPortionService>();
        _mealServiceMock = new Mock<IMealService>();
        _foodItemServiceMock = new Mock<IFoodItemService>();
        _controller = new PortionController(_portionServiceMock.Object, _mealServiceMock.Object, _foodItemServiceMock.Object);
    }

    [Test]
    public async Task GetPortionsByMealId_InvalidMeal_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var id = Guid.NewGuid().ToString();
        _mealServiceMock.Setup(s => s.MealIsByUserIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(false);

        // Act
        var result = await _controller.GetPortionsByMealId(id);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task GetPortionsByMealId_ValidMeal_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var id = Guid.NewGuid().ToString();
        _mealServiceMock.Setup(s => s.MealIsByUserIdAsync(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(true);
        _portionServiceMock.Setup(s => s.GetPortionsByMealIdAsync(It.IsAny<Guid>())).ReturnsAsync(new[] { new PortionDisplayModel() });

        // Act
        var result = await _controller.GetPortionsByMealId(id);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task AddPortion_InvalidMeal_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new PortionFormModel { MealId = Guid.NewGuid(), FoodItemId = 0 };
        _mealServiceMock.Setup(s => s.MealIsByUserIdAsync(model.MealId, It.IsAny<Guid>())).ReturnsAsync(false);

        // Act
        var result = await _controller.AddPortion(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task AddPortion_InvalidFoodItem_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new PortionFormModel { MealId = Guid.NewGuid(), FoodItemId = 0 };
        _mealServiceMock.Setup(s => s.MealIsByUserIdAsync(model.MealId, It.IsAny<Guid>())).ReturnsAsync(true);
        _foodItemServiceMock.Setup(s => s.FoodItemExistsByIdAsync(model.FoodItemId)).ReturnsAsync(false);

        // Act
        var result = await _controller.AddPortion(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task AddPortion_ValidModel_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new PortionFormModel { MealId = Guid.NewGuid(), FoodItemId = 0 };
        _mealServiceMock.Setup(s => s.MealIsByUserIdAsync(model.MealId, It.IsAny<Guid>())).ReturnsAsync(true);
        _foodItemServiceMock.Setup(s => s.FoodItemExistsByIdAsync(model.FoodItemId)).ReturnsAsync(true);

        // Act
        var result = await _controller.AddPortion(model);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
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
