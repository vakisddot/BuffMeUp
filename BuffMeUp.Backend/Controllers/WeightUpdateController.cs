using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeightUpdateController : ControllerBase
{
    readonly IPersonalStatsService _personalStatsService;

    public WeightUpdateController(IPersonalStatsService personalStatsService)
    {
        _personalStatsService = personalStatsService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]WeightUpdateFormModel model)
    {
        var userId = IdentifyUser();

        if (userId != null && !await _personalStatsService.PersonalStatsExistAsync(Guid.Parse(userId)))
        {
            ModelState.AddModelError("PersonalStats", "User does not have personal stats!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _personalStatsService.UpdateWeightAsync(model.Weight, Guid.Parse(userId!));

        return Ok(new {});
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
