using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController : ControllerBase
{
    readonly IWorkoutService _workoutService;
    readonly IExerciseSetService _exerciseSetService;
    readonly IExerciseTemplateService _exerciseTemplateService;

    public WorkoutController(IWorkoutService workoutService, IExerciseSetService exerciseSetService, IExerciseTemplateService exerciseTemplateService)
    {
        _workoutService = workoutService;
        _exerciseSetService = exerciseSetService;
        _exerciseTemplateService = exerciseTemplateService;
    }

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> AllWorkouts(int page, int resultCount)
    {
        var userId = IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var workouts = await _workoutService.GetWorkoutsByPageAsync(page, resultCount, Guid.Parse(userId!));

        return Ok(workouts);
    }

    [HttpPost]
    [Route("StartNew")]
    public async Task<IActionResult> StartNewWorkout()
    {
        var userId = IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _workoutService.StartNewWorkoutAsync(Guid.Parse(userId!));

        return Ok(new {});
    }

    [HttpGet]
    [Route("Details")]
    public async Task<IActionResult> Details(Guid id)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(id);

        if (workout == null || (userId != null && workout.UserId != Guid.Parse(userId)))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        return Ok(workout);
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update(WorkoutFormModel model)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(model.Id);

        if (workout == null || (userId != null && workout.UserId != Guid.Parse(userId)))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _workoutService.UpdateWorkoutAsync(model);

        return Ok(new {});
    }

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(id);

        if (workout == null || (userId != null && workout.UserId != Guid.Parse(userId)))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _workoutService.DeleteWorkoutAsync(id);

        return Ok(new {});
    }

    [HttpPost]
    [Route("AddSet")]
    public async Task<IActionResult> AddExerciseSet(ExerciseSetFormModel model)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(model.WorkoutId);

        if (workout == null || (userId != null && workout.UserId != Guid.Parse(userId)))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _exerciseSetService.CreateExerciseSetAsync(model);

        return Ok(new {});
    }

    [HttpGet]
    [Route("Templates")]
    public async Task<IActionResult> GetExerciseTemplates([FromQuery] string q)
    {
        var userId = IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var templates = await _exerciseTemplateService.GetExerciseTemplatesAsync(Guid.Parse(userId!), q);

        return Ok(templates);
    }

    [HttpGet]
    [Route("Sets")]
    public async Task<IActionResult> GetExerciseSets([FromQuery]Guid workoutId)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(workoutId);

        if (workout == null || (userId != null && workout.UserId != Guid.Parse(userId)))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var sets = await _exerciseSetService.GetExerciseSetsAsync(workoutId);

        return Ok(sets);
    }

    string? IdentifyUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var userId = identity?.FindFirst("userId")?.Value;

        if (identity == null || userId == null)
        {
            ModelState.AddModelError("User", "Failed to identify user!");
        }

        return userId;
    }
}
