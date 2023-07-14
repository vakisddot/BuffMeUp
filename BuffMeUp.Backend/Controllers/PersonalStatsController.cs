using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
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
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var userId = identity?.FindFirst("userId")?.Value;

        if (identity == null || userId == null)
        {
            ModelState.AddModelError("User", "Failed to identify user!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var personalStats = await _personalStatsService.GetPersonalStatsAsync(Guid.Parse(userId));

        return Ok(personalStats);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PersonalStatsFormModel model)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var userId = identity?.FindFirst("userId")?.Value;

        if (identity == null || userId == null)
        {
            ModelState.AddModelError("User", "Failed to identify user!");
        }

        if (await _personalStatsService.PersonalStatsExistAsync(Guid.Parse(userId)))
        {
            ModelState.AddModelError("PersonalStats", "User already has personal stats!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _personalStatsService.CreatePersonalStatsAsync(model, Guid.Parse(userId));

        return Ok();
    }
}
