using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BuffMeUp.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogInController : ControllerBase
{
    readonly IAccountService _accountService;

    public LogInController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]UserLogInViewModel user)
    {
        var token = await _accountService.LogInUserAsync(user);

        if (token == null)
        {
            ModelState.AddModelError("User", "Invalid username and/or password!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                Errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() ?? new[] { "" })
            });
        }

        Console.WriteLine($"User '{user.Username}' logged in successfully!");

        return Ok(new { Token = token });
    }
}
