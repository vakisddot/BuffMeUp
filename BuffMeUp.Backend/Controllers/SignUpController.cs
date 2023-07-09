using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BuffMeUp.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SignUpController : ControllerBase
{
    readonly ISignUpService _signUpService;

    public SignUpController(ISignUpService signUpService)
    {
        _signUpService = signUpService;
    }

    [HttpPost]
    public IActionResult Post([FromBody]UserSignUpViewModel newUser)
    {
        if (!_signUpService.IsEmailAvailable(newUser.Email))
        {
            ModelState.AddModelError("Email", "Email is already taken!");
        }        

        if (!_signUpService.IsUsernameAvailable(newUser.Username))
        {
            ModelState.AddModelError("Username", "Username is already taken!");
        }

        if (!ModelState.IsValid)
        {
            Console.WriteLine("Invalid model state!");

            return new JsonResult(new { Errors = ModelState
                .ToDictionary(
                    kvp => kvp.Key, 
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() ?? new[] { "" }) })
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }

        _signUpService.RegisterUser(newUser);

        return Ok();
    }
}
