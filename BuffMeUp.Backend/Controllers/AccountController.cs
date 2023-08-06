using BuffMeUp.Backend.Common;
using BuffMeUp.Backend.Services.Interfaces;
using BuffMeUp.Backend.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace BuffMeUp.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : BaseController
{
    readonly IAccountService _accountService;
    readonly IRoleService _roleService;

    public AccountController(IAccountService accountService, IRoleService roleService)
    {
        _accountService = accountService;
        _roleService = roleService;
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

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        if (!IsAuthorizedAs("admin"))
        {
            ModelState.AddModelError("User", "You are not authorized to do this action!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var users = await _accountService.GetAllUsersAsync();

        return Ok(users);
    }

    [HttpGet]
    [Route("Avatar")]
    public async Task<IActionResult> GetUserAvatar()
    {
        var userId = IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        var avatar = await _accountService.GetAvatarAsync(Guid.Parse(userId!));

        return Ok(avatar);
    }

    [HttpPut]
    [Route("Role")]
    public async Task<IActionResult> UpdateUserRole(UserUpdateModel model)
    {
        bool isValidId = Guid.TryParse(model.Id, out var userId);
        var actorId = IdentifyUser();

        if (!IsAuthorizedAs("admin"))
        {
            ModelState.AddModelError("User", "You are not authorized to do this action!");
        }

        if (isValidId && _accountService.IsOGAdmin(userId))
        {
            ModelState.AddModelError("User", "You cannot change the role of the OG admin!");
        }

        if (!await _roleService.IsValidRoleAsync(model.Role))
        {
            ModelState.AddModelError("Role", "No role with such name exists!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _accountService.UpdateUserRoleAsync(userId, model.Role);

        return Ok(new { });
    }

    [HttpPut]
    [Route("Avatar")]
    public async Task<IActionResult> UpdateAvatar(AvatarFormModel model)
    {
        var userId = IdentifyUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _accountService.AddAvatarAsync(Guid.Parse(userId!), Convert.FromBase64String(model.Avatar));
        return Ok(new { });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAccount([FromBody]AccountDeleteModel model)
    {
        var actorId = IdentifyUser();
        var userIsValid = Guid.TryParse(model.Id, out var userId);
        var userIsAdmin = await _accountService.IsAdminAccountAsync(userId);

        if (actorId == null || !userIsValid || userIsAdmin || (actorId != model.Id && !IsAuthorizedAs("admin")))
        {
            ModelState.AddModelError("User", "You cannot delete this account!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(Utils.GetErrorsObject(ModelState));
        }

        await _accountService.DeleteUserAsync(userId);

        return Ok(new { });
    }
}
