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
            return Unauthorized();
        }

        Console.WriteLine($"User '{user.Username}' logged in successfully!");

        return Ok(new { Token = token });
    }
}
