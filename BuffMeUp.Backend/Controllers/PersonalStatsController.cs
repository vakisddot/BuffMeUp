﻿using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BuffMeUp.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonalStatsController : BaseController
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

        await _personalStatsService.CreatePersonalStatsAsync(model, Guid.Parse(userId!));

        return Ok();
    }

    [HttpPut]
    [Route("Stats")]
    public async Task<IActionResult> UpdateStats([FromBody] PersonalStatsUpdateModel model)
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

        await _personalStatsService.UpdateStatsAsync(model, Guid.Parse(userId!));

        return Ok();
    }

    [HttpPut]
    [Route("Weight")]
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

        return Ok();
    }
}