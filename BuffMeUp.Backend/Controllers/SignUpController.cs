using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BuffMeUp.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SignUpController : ControllerBase
{
    readonly IAccountService _accountService;

    public SignUpController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]UserSignUpViewModel newUser)
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
            return new JsonResult(new { Errors = ModelState
                .ToDictionary(
                    kvp => kvp.Key, 
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() ?? new[] { "" }) })
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }

        var token = await _accountService.RegisterUserAsync(newUser);
        Console.WriteLine($"User '{newUser.Username}' registered successfully!");

        return Ok(new { Token = token });
    }
}
