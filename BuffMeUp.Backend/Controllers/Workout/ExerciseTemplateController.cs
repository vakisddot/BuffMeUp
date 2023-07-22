using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Controllers.Workout;

[ApiController]
[Route("api/[controller]")]
public class ExerciseTemplateController : ControllerBase
{
    readonly IExerciseTemplateService _exerciseTemplateService;

    public ExerciseTemplateController(IExerciseTemplateService exerciseTemplateService)
    {
        _exerciseTemplateService = exerciseTemplateService;
    }

    [HttpGet]
    [Route("Query")]
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

    [HttpPost]
    [Route("New")]
    public async Task<IActionResult> CreateExerciseTemplate(ExerciseTemplateFormModel model)
    {
        var userId = IdentifyUser();

        if (await _exerciseTemplateService.ExerciseTemplateExistsByNameAsync(model.Name))
        {
            ModelState.AddModelError("ExerciseTemplate", "Exercise already exists!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _exerciseTemplateService.CreateExerciseTemplateAsync(model, Guid.Parse(userId!));

        return Ok(new { });
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
