using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BuffMeUp.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    [Route("SignUp")]
    public async Task<IActionResult> SignUp([FromBody] UserSignUpFormModel newUser)
    {
        if (!await _accountService.IsEmailAvailableAsync(newUser.Email))
        {
            ModelState.AddModelError("Email", "Email is already taken!");
        }

        if (!await _accountService.IsUsernameAvailableAsync(newUser.Username))
        {
            ModelState.AddModelError("Username", "Username is already taken!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var token = await _accountService.RegisterUserAsync(newUser);
        Console.WriteLine($"User '{newUser.Username}' registered successfully!");

        return Ok(new { Token = token });
    }

    [HttpPost]
    [Route("LogIn")]
    public async Task<IActionResult> LogIn([FromBody]UserLogInFormModel user)
    {
        var token = await _accountService.LogInUserAsync(user);

        if (token == null)
        {
            ModelState.AddModelError("User", "Invalid username and/or password!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        Console.WriteLine($"User '{user.Username}' logged in successfully!");

        return Ok(new { Token = token });
    }
}
