using BuffMeUp.Backend.Controllers.Food;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Food;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Tests;

[TestFixture]
public class FoodItemControllerTests
{
    private Mock<IFoodItemService> _foodItemServiceMock;
    private FoodItemController _controller;

    [SetUp]
    public void SetUp()
    {
        _foodItemServiceMock = new Mock<IFoodItemService>();
        _controller = new FoodItemController(_foodItemServiceMock.Object);
    }

    [Test]
    public async Task AddNewFoodItem_FoodExists_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new FoodItemFormModel { Name = "food" };
        _foodItemServiceMock.Setup(s => s.FoodItemExistsByNameAsync(model.Name)).ReturnsAsync(true);

        // Act
        var result = await _controller.AddNewFoodItem(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task AddNewFoodItem_FoodDoesNotExist_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new FoodItemFormModel { Name = "food" };
        _foodItemServiceMock.Setup(s => s.FoodItemExistsByNameAsync(model.Name)).ReturnsAsync(false);

        // Act
        var result = await _controller.AddNewFoodItem(model);

        // Assert
        Assert.IsInstanceOf<OkResult>(result);
    }

    [Test]
    public async Task GetFoodItems_ValidUser_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        _foodItemServiceMock.Setup(s => s.GetFoodItemsAsync(It.IsAny<Guid>(), It.IsAny<string>())).ReturnsAsync(new[] { new FoodItemDisplayModel() });

        // Act
        var result = await _controller.GetFoodItems(null);

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
