using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuffMeUp.Backend.Controllers;

public class BaseController : ControllerBase
{
    protected string? IdentifyUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var userId = identity?.FindFirst("userId")?.Value;

        if (identity == null || userId == null)
        {
            ModelState.AddModelError("User", "Failed to identify user!");
        }

        return userId;
    }

    protected bool IsAuthorizedAs(string role)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var userRole = identity?.FindFirst("userRole")?.Value;

        return userRole != null && userRole.ToLower() == role.ToLower();
    }
}
