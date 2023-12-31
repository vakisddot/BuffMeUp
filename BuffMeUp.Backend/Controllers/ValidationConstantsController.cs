﻿using Microsoft.AspNetCore.Mvc;

namespace BuffMeUp.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValidationConstantsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string modelName)
        => modelName switch
        {
            "User" => Ok(Common.ValidationConstants.ForUser.Serialized),
            "PersonalStats" => Ok(Common.ValidationConstants.ForPersonalStats.Serialized),
            "ExerciseSet" => Ok(Common.ValidationConstants.ForExerciseSet.Serialized),
            "ExerciseTemplate" => Ok(Common.ValidationConstants.ForExerciseTemplate.Serialized),
            "FoodItem" => Ok(Common.ValidationConstants.ForFoodItem.Serialized),

            _ => NotFound(new { })
        };
}
