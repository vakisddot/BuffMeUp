using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Food;
using Microsoft.AspNetCore.Mvc;

namespace BuffMeUp.Backend.Controllers.Food;

[ApiController]
[Route("api/[controller]")]
public class PortionController : BaseController
{
    readonly IPortionService _portionService;
    readonly IMealService _mealService;
    readonly IFoodItemService _foodItemService;

    public PortionController(IPortionService portionService, IMealService mealService, IFoodItemService foodItemService)
    {
        _portionService = portionService;
        _mealService = mealService;
        _foodItemService = foodItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPortionsByMealId(string id)
    {
        var userId = IdentifyUser();

        var idIsValid = Guid.TryParse(id, out var validMealId);

        var mealIsValid = userId != null && idIsValid
            ? await _mealService.MealIsByUserIdAsync(validMealId, Guid.Parse(userId))
            : false;

        if (!mealIsValid)
        {
            ModelState.AddModelError("Meal", "You cannot get the portions for this meal!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var portions = await _portionService.GetPortionsByMealIdAsync(validMealId);

        return Ok(portions);
    }

    [HttpPost]
    public async Task<IActionResult> AddPortion(PortionFormModel model)
    {
        var userId = IdentifyUser();

        var mealIsValid = userId != null
            ? await _mealService.MealIsByUserIdAsync(model.MealId, Guid.Parse(userId)) 
            : false;

        var foodItemExists = await _foodItemService.FoodItemExistsByIdAsync(model.FoodItemId);

        if (!mealIsValid)
        {
            ModelState.AddModelError("Meal", "You cannot add portions to this meal!");
        }

        if (!foodItemExists)
        {
            ModelState.AddModelError("FoodItem", "Food item doesn't exist!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var id = await _portionService.CreatePortionAsync(model);

        return Ok(new { Id = id });
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePortion(PortionDeleteModel model)
    {
        IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _portionService.DeletePortionAsync(model.Id);

        return Ok();
    }
}
