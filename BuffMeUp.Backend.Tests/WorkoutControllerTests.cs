using BuffMeUp.Backend.Controllers.Workout;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Tests;

[TestFixture]
public class WorkoutControllerTests
{
    private Mock<IWorkoutService> _workoutServiceMock;
    private Mock<IExerciseTemplateService> _exerciseTemplateServiceMock;
    private WorkoutController _controller;

    [SetUp]
    public void SetUp()
    {
        _workoutServiceMock = new Mock<IWorkoutService>();
        _exerciseTemplateServiceMock = new Mock<IExerciseTemplateService>();
        _controller = new WorkoutController(_workoutServiceMock.Object, _exerciseTemplateServiceMock.Object);
    }

    [Test]
    public async Task AllWorkouts_ValidUser_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        _workoutServiceMock.Setup(s => s.GetWorkoutsByPageAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Guid>())).ReturnsAsync(new[] { new WorkoutSearchModel() });

        // Act
        var result = await _controller.AllWorkouts(1, 10);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task StartNewWorkout_ValidUser_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");

        // Act
        var result = await _controller.StartNewWorkout();

        // Assert
        Assert.IsInstanceOf<OkResult>(result);
    }

    [Test]
    public async Task Details_InvalidWorkout_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var id = Guid.NewGuid();
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(id)).ReturnsAsync((WorkoutDisplayModel)null);

        // Act
        var result = await _controller.Details(id);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task Details_ValidWorkout_ReturnsOk()
    {
        // Arrange
        var userId = Guid.NewGuid();
        SetUserContext(userId.ToString(), "user");
        var id = Guid.NewGuid();
        var workout = new WorkoutDisplayModel { UserId = userId };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(id)).ReturnsAsync(workout);

        // Act
        var result = await _controller.Details(id);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task Update_InvalidWorkout_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new WorkoutFormModel { Id = Guid.NewGuid() };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(model.Id)).ReturnsAsync((WorkoutDisplayModel)null);

        // Act
        var result = await _controller.Update(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task Update_ValidModel_ReturnsOk()
    {
        // Arrange
        var userId = Guid.NewGuid();
        SetUserContext(userId.ToString(), "user");
        var model = new WorkoutFormModel { Id = Guid.NewGuid() };
        var workout = new WorkoutDisplayModel { UserId = userId };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(model.Id)).ReturnsAsync(workout);

        // Act
        var result = await _controller.Update(model);

        // Assert
        Assert.IsInstanceOf<OkResult>(result);
    }

    [Test]
    public async Task Delete_InvalidWorkout_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new WorkoutDeleteModel { Id = Guid.NewGuid() };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(model.Id)).ReturnsAsync((WorkoutDisplayModel)null);

        // Act
        var result = await _controller.Delete(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task Delete_ValidModel_ReturnsOk()
    {
        // Arrange
        var userId = Guid.NewGuid();
        SetUserContext(userId.ToString(), "user");
        var model = new WorkoutDeleteModel { Id = Guid.NewGuid() };
        var workout = new WorkoutDisplayModel { UserId = userId };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(model.Id)).ReturnsAsync(workout);

        // Act
        var result = await _controller.Delete(model);

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
