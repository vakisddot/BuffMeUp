using BuffMeUp.Backend.Common;
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
    public async Task<IActionResult> Post([FromBody]UserSignUpFormModel newUser)
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
}
