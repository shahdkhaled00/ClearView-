using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using ClearView.DTOs;
using ClearView.Services;

[Route("api/users")]
[ApiController]
[Authorize] 
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    //show profile
    [HttpGet("profile")]
    public async Task<IActionResult> GetUserProfile()
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Unauthorized(new { message = "Invalid user ID." });

        var user = await _userService.GetUserProfileAsync(userId);
        if (user == null)
            return NotFound(new { message = "User not found." });

        return Ok(user);
    }


    // Update user profile
    [HttpPut("Update_profile")]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileDto updatedUser)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Unauthorized(new { message = "Invalid user ID." });

        var result = await _userService.UpdateUserProfileAsync(userId, updatedUser);

        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }

        return Ok(new { message = "User profile updated successfully" });
    }
}
