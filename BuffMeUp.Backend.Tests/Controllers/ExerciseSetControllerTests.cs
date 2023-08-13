using BuffMeUp.Backend.Controllers.Workout;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Tests.Controllers;

[TestFixture]
public class ExerciseSetControllerTests
{
    private Mock<IExerciseSetService> _exerciseSetServiceMock;
    private Mock<IWorkoutService> _workoutServiceMock;
    private Mock<IExerciseTemplateService> _exerciseTemplateServiceMock;
    private ExerciseSetController _controller;

    [SetUp]
    public void SetUp()
    {
        _exerciseSetServiceMock = new Mock<IExerciseSetService>();
        _workoutServiceMock = new Mock<IWorkoutService>();
        _exerciseTemplateServiceMock = new Mock<IExerciseTemplateService>();
        _controller = new ExerciseSetController(_workoutServiceMock.Object, _exerciseSetServiceMock.Object, _exerciseTemplateServiceMock.Object);
    }

    [Test]
    public async Task GetAllByWorkout_InvalidWorkout_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var workoutId = Guid.NewGuid();
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(workoutId)).ReturnsAsync((WorkoutDisplayModel)null);

        // Act
        var result = await _controller.GetAllByWorkout(workoutId);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task GetAllByWorkout_ValidWorkout_ReturnsOk()
    {
        // Arrange
        var userId = Guid.NewGuid();
        SetUserContext(userId.ToString(), "user");
        var workoutId = Guid.NewGuid();
        var workout = new WorkoutDisplayModel { UserId = userId };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(workoutId)).ReturnsAsync(workout);
        _exerciseSetServiceMock.Setup(s => s.GetExerciseSetsByWorkoutIdAsync(workoutId, false)).ReturnsAsync(new[] { new ExerciseSetDisplayModel() });

        // Act
        var result = await _controller.GetAllByWorkout(workoutId);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task DeleteExerciseSet_InvalidSet_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new ExerciseSetDeleteModel { Id = Guid.NewGuid() };
        _exerciseSetServiceMock.Setup(s => s.GetExerciseSetByIdAsync(model.Id)).ReturnsAsync((ExerciseSetDisplayModel)null);

        // Act
        var result = await _controller.DeleteExerciseSet(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task DeleteExerciseSet_ValidSet_ReturnsOk()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new ExerciseSetDeleteModel { Id = Guid.NewGuid() };
        _exerciseSetServiceMock.Setup(s => s.GetExerciseSetByIdAsync(model.Id)).ReturnsAsync(new ExerciseSetDisplayModel());

        // Act
        var result = await _controller.DeleteExerciseSet(model);

        // Assert
        Assert.IsInstanceOf<OkResult>(result);
    }

    [Test]
    public async Task AddExerciseSet_InvalidWorkout_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new ExerciseSetFormModel { WorkoutId = Guid.NewGuid() };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(model.WorkoutId)).ReturnsAsync((WorkoutDisplayModel)null);

        // Act
        var result = await _controller.AddExerciseSet(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task AddExerciseSet_ValidModel_ReturnsOk()
    {
        // Arrange
        var userId = Guid.NewGuid();
        SetUserContext(userId.ToString(), "user");
        var model = new ExerciseSetFormModel { WorkoutId = Guid.NewGuid() };
        var workout = new WorkoutDisplayModel { UserId = userId };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(model.WorkoutId)).ReturnsAsync(workout);

        // Act
        var result = await _controller.AddExerciseSet(model);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task AddExerciseSetWithExerciseName_InvalidWorkout_ReturnsBadRequest()
    {
        // Arrange
        SetUserContext(Guid.NewGuid().ToString(), "user");
        var model = new ExerciseSetUpdateModel { WorkoutId = Guid.NewGuid() };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(model.WorkoutId)).ReturnsAsync((WorkoutDisplayModel)null);

        // Act
        var result = await _controller.AddExerciseSetWithExerciseName(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task AddExerciseSetWithExerciseName_InvalidTemplate_ReturnsBadRequest()
    {
        // Arrange
        var userId = Guid.NewGuid();
        SetUserContext(userId.ToString(), "user");
        var model = new ExerciseSetUpdateModel { WorkoutId = Guid.NewGuid() };
        var workout = new WorkoutDisplayModel { UserId = userId };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(model.WorkoutId)).ReturnsAsync(workout);
        _exerciseTemplateServiceMock.Setup(s => s.GetExerciseTemplatesAsync(It.IsAny<Guid>(), It.IsAny<string>())).ReturnsAsync(Enumerable.Empty<ExerciseTemplateDisplayModel>());

        // Act
        var result = await _controller.AddExerciseSetWithExerciseName(model);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task AddExerciseSetWithExerciseName_ValidModel_ReturnsOk()
    {
        // Arrange
        var userId = Guid.NewGuid();
        SetUserContext(userId.ToString(), "user");
        var model = new ExerciseSetUpdateModel { WorkoutId = Guid.NewGuid() };
        var workout = new WorkoutDisplayModel { UserId = userId };
        _workoutServiceMock.Setup(s => s.GetWorkoutDetailsAsync(model.WorkoutId)).ReturnsAsync(workout);
        _exerciseTemplateServiceMock.Setup(s => s.GetExerciseTemplatesAsync(It.IsAny<Guid>(), It.IsAny<string>())).ReturnsAsync(new[] { new ExerciseTemplateDisplayModel { Id = Guid.NewGuid() } });

        // Act
        var result = await _controller.AddExerciseSetWithExerciseName(model);

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
