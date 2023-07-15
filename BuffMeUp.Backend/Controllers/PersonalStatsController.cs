using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PersonalStatsController : ControllerBase
{
    readonly IPersonalStatsService _personalStatsService;

    public PersonalStatsController(IPersonalStatsService personalStatsService)
    {
        _personalStatsService = personalStatsService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var personalStats = await _personalStatsService.GetPersonalStatsAsync(Guid.Parse(userId!));

        return Ok(personalStats);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitStats([FromBody] PersonalStatsFormModel model)
    {
        var userId = IdentifyUser();

        if (userId != null && await _personalStatsService.PersonalStatsExistAsync(Guid.Parse(userId)))
        {
            ModelState.AddModelError("PersonalStats", "User already has personal stats!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _personalStatsService.CreatePersonalStatsAsync(model, Guid.Parse(userId));

        return Ok(new {});
    }

    [HttpPost]
    [Route("UpdateWeight")]
    public async Task<IActionResult> UpdateWeight([FromBody] WeightUpdateFormModel model)
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