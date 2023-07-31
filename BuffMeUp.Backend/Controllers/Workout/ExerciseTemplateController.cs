using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Workouts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Controllers.Workout;

[ApiController]
[Route("api/[controller]")]
public class ExerciseTemplateController : BaseController
{
    readonly IExerciseTemplateService _exerciseTemplateService;

    public ExerciseTemplateController(IExerciseTemplateService exerciseTemplateService)
    {
        _exerciseTemplateService = exerciseTemplateService;
    }

    [HttpGet]
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
}
