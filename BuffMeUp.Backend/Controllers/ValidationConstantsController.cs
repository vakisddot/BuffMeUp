using Microsoft.AspNetCore.Mvc;

namespace BuffMeUp.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ValidationConstantsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string modelName)
        => modelName switch
        {
            "User" => new JsonResult(Common.ValidationConstants.ForUser.Serialized),

            _ => new JsonResult(new { })
        };
}
