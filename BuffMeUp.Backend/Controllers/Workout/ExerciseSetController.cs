using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Controllers.Workout;

[Route("api/[controller]")]
[ApiController]
public class ExerciseSetController : ControllerBase
{
    readonly IWorkoutService _workoutService;
    readonly IExerciseSetService _exerciseSetService;
    readonly IExerciseTemplateService _exerciseTemplateService;

    public ExerciseSetController(IWorkoutService workoutService, IExerciseSetService exerciseSetService, IExerciseTemplateService exerciseTemplateService)
    {
        _workoutService = workoutService;
        _exerciseSetService = exerciseSetService;
        _exerciseTemplateService = exerciseTemplateService;
    }

    [HttpGet]
    [Route("AllByWorkout")]
    public async Task<IActionResult> GetAllByWorkout([FromQuery] Guid workoutId)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(workoutId);

        if (workout == null || userId != null && workout.UserId != Guid.Parse(userId))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var sets = await _exerciseSetService.GetExerciseSetsByWorkoutIdAsync(workoutId);

        return Ok(sets);
    }

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> DeleteExerciseSet(ExerciseSetDeleteModel model)
    {
        IdentifyUser();

        var set = await _exerciseSetService.GetExerciseSetByIdAsync(model.Id);

        if (set == null)
        {
            ModelState.AddModelError("ExerciseSet", "Exercise set not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _exerciseSetService.DeleteExerciseSetAsync(model.Id);

        return Ok(new { });
    }

    [HttpPost]
    [Route("Add")]
    public async Task<IActionResult> AddExerciseSet(ExerciseSetFormModel model)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(model.WorkoutId);

        if (workout == null || userId != null && workout.UserId != Guid.Parse(userId))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var newId = await _exerciseSetService.CreateExerciseSetAsync(model);

        return Ok(new { Id = newId });
    }

    [HttpPost]
    [Route("AddWithExerciseName")]
    public async Task<IActionResult> AddExerciseSetWithExerciseName(ExerciseSetUpdateModel model)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(model.WorkoutId);

        if (workout == null || userId != null && workout.UserId != Guid.Parse(userId))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        var templates = await _exerciseTemplateService.GetExerciseTemplatesAsync(Guid.Parse(userId!), model.ExerciseName);
        var template = templates.FirstOrDefault();

        if (template == null)
        {
            ModelState.AddModelError("ExerciseTemplate", "Exercise template not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var newModel = new ExerciseSetFormModel
        {
            Reps = model.Reps,
            Weight = model.Weight,
            WorkoutId = model.WorkoutId,
            ExerciseTemplateId = template!.Id,
        };

        newModel.ExerciseTemplateId = template!.Id;

        var id = await _exerciseSetService.CreateExerciseSetAsync(newModel);

        return Ok(new { Id = id });
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
