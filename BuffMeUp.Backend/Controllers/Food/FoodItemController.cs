using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Food;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuffMeUp.Backend.Controllers.Food;

[Route("api/[controller]")]
[ApiController]
public class FoodItemController : BaseController
{
    readonly IFoodItemService _foodItemService;

    public FoodItemController(IFoodItemService foodItemService)
    {
        _foodItemService = foodItemService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewFoodItem(FoodItemFormModel model)
    {
        var userId = IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _foodItemService.AddNewFoodItemAsync(model, Guid.Parse(userId!));

        return Ok(new { });
    }

    [HttpGet]
    public async Task<IActionResult> GetFoodItems([FromQuery] string q)
    {
        var userId = IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var foodItems = await _foodItemService.GetFoodItemsAsync(Guid.Parse(userId!), q);

        return Ok(foodItems);
    }
}
