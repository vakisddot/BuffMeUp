using BuffMeUp.Backend.Controllers.Workout;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Tests.Controllers;

[TestFixture]
public class ExerciseTemplateControllerTests
{
    private Mock<IExerciseTemplateService> _exerciseTemplateServiceMock;
    private ExerciseTemplateController _controller;

    [SetUp]
    public void SetUp()
    {
        _exerciseTemplateServiceMock = new Mock<IExerciseTemplateService>();
        _controller = new ExerciseTemplateController(_exerciseTemplateServiceMock.Object);
    }

    [Test]
    public async Task GetExerciseTemplates_ValidUser_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        _exerciseTemplateServiceMock.Setup(s => s.GetExerciseTemplatesAsync(It.IsAny<Guid>(), It.IsAny<string>())).ReturnsAsync(new[] { new ExerciseTemplateDisplayModel() });

        // Act
        var result = await _controller.GetExerciseTemplates(null);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task CreateExerciseTemplate_ExistingTemplate_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new ExerciseTemplateFormModel { Name = "template" };
        _exerciseTemplateServiceMock.Setup(s => s.ExerciseTemplateExistsByNameAsync(model.Name)).ReturnsAsync(true);

        // Act
        var result = await _controller.CreateExerciseTemplate(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task CreateExerciseTemplate_NoExistingTemplate_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new ExerciseTemplateFormModel { Name = "template" };
        _exerciseTemplateServiceMock.Setup(s => s.ExerciseTemplateExistsByNameAsync(model.Name)).ReturnsAsync(false);

        // Act
        var result = await _controller.CreateExerciseTemplate(model);

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
