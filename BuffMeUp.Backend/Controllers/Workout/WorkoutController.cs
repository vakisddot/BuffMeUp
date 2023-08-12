using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.AspNetCore.Mvc;

namespace BuffMeUp.Backend.Controllers.Workout;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController : BaseController
{
    readonly IWorkoutService _workoutService;
    readonly IExerciseTemplateService _exerciseTemplateService;

    public WorkoutController(IWorkoutService workoutService, IExerciseTemplateService exerciseTemplateService)
    {
        _workoutService = workoutService;
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
    public async Task<IActionResult> StartNewWorkout()
    {
        var userId = IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _workoutService.StartNewWorkoutAsync(Guid.Parse(userId!));

        return Ok();
    }

    [HttpGet]
    [Route("Details")]
    public async Task<IActionResult> Details(Guid id)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(id);

        if (workout == null || userId != null && workout.UserId != Guid.Parse(userId))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        return Ok(workout);
    }

    [HttpPut]
    public async Task<IActionResult> Update(WorkoutFormModel model)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(model.Id);

        if (workout == null || userId != null && workout.UserId != Guid.Parse(userId))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _workoutService.UpdateWorkoutAsync(model);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(WorkoutDeleteModel model)
    {
        var userId = IdentifyUser();

        var workout = await _workoutService.GetWorkoutDetailsAsync(model.Id);

        if (workout == null || userId != null && workout.UserId != Guid.Parse(userId))
        {
            ModelState.AddModelError("Workout", "Workout not found!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _workoutService.DeleteWorkoutAsync(model.Id);

        return Ok();
    }
}
