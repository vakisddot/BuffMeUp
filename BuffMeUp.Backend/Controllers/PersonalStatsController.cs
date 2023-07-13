using BuffMeUp.Backend.Services.Interfaces;
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
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity == null)
        {
            return Unauthorized();
        }

        var id = identity.FindFirst("userId")?.Value;

        if (id == null)
        {
            return Unauthorized();
        }

        var personalStats = await _personalStatsService.GetPersonalStatsAsync(Guid.Parse(id));

        return Ok(personalStats);
    }
}
