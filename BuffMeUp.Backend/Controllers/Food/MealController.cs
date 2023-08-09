using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Food;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BuffMeUp.Backend.Controllers.Food;

[Route("api/[controller]")]
[ApiController]
public class MealController : BaseController
{
    readonly IMealService _mealService;

    public MealController(IMealService mealService)
    {
        _mealService = mealService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMealsByDay(string date)
    {
        var userId = IdentifyUser();

        bool dateIsValid = DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime);

        if (!dateIsValid)
        {
            ModelState.AddModelError("Date", "Invalid date!");
        }

        if (!ModelState.IsValid) 
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var meals = await _mealService.GetMealsByDateAsync(dateTime, Guid.Parse(userId!));

        return Ok(meals);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewMeal()
    {
        var userId = IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _mealService.AddNewMealAsync(Guid.Parse(userId!));

        return Ok(new { });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMeal(MealDeleteModel model)
    {
        var userId = IdentifyUser();

        if (userId != null && !await _mealService.MealIsByUserIdAsync(model.Id, Guid.Parse(userId!)))
        {
            ModelState.AddModelError("Meal", "You can't delete this meal!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _mealService.DeleteMealAsync(model.Id);

        return Ok(new { });
    }
}
