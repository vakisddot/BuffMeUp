using BuffMeUp.Backend.Controllers;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Tests;

[TestFixture]
public class PersonalStatsControllerTests
{
    private Mock<IPersonalStatsService> _personalStatsServiceMock;
    private PersonalStatsController _controller;

    [SetUp]
    public void SetUp()
    {
        _personalStatsServiceMock = new Mock<IPersonalStatsService>();
        _controller = new PersonalStatsController(_personalStatsServiceMock.Object);
    }

    [Test]
    public async Task Get_ValidUser_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        _personalStatsServiceMock.Setup(s => s.GetPersonalStatsAsync(It.IsAny<Guid>())).ReturnsAsync(new PersonalStatsDisplayModel());

        // Act
        var result = await _controller.Get();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task SubmitStats_ExistingPersonalStats_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new PersonalStatsFormModel();
        _personalStatsServiceMock.Setup(s => s.PersonalStatsExistAsync(It.IsAny<Guid>())).ReturnsAsync(true);

        // Act
        var result = await _controller.SubmitStats(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task SubmitStats_NoExistingPersonalStats_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new PersonalStatsFormModel();
        _personalStatsServiceMock.Setup(s => s.PersonalStatsExistAsync(It.IsAny<Guid>())).ReturnsAsync(false);

        // Act
        var result = await _controller.SubmitStats(model);

        // Assert
        Assert.IsInstanceOf<OkResult>(result);
    }

    [Test]
    public async Task UpdateStats_NoExistingPersonalStats_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new PersonalStatsUpdateModel();
        _personalStatsServiceMock.Setup(s => s.PersonalStatsExistAsync(It.IsAny<Guid>())).ReturnsAsync(false);

        // Act
        var result = await _controller.UpdateStats(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task UpdateStats_ExistingPersonalStats_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new PersonalStatsUpdateModel();
        _personalStatsServiceMock.Setup(s => s.PersonalStatsExistAsync(It.IsAny<Guid>())).ReturnsAsync(true);

        // Act
        var result = await _controller.UpdateStats(model);

        // Assert
        Assert.IsInstanceOf<OkResult>(result);
    }

    [Test]
    public async Task UpdateWeight_NoExistingPersonalStats_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new WeightUpdateFormModel();
        _personalStatsServiceMock.Setup(s => s.PersonalStatsExistAsync(It.IsAny<Guid>())).ReturnsAsync(false);

        // Act
        var result = await _controller.UpdateWeight(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task UpdateWeight_ExistingPersonalStats_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new WeightUpdateFormModel();
        _personalStatsServiceMock.Setup(s => s.PersonalStatsExistAsync(It.IsAny<Guid>())).ReturnsAsync(true);

        // Act
        var result = await _controller.UpdateWeight(model);

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
