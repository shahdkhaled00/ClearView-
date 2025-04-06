using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ClearView.DTOs;
using ClearView.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[Route("api/doctors")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IUserService _userService;

    public DoctorsController(IUserService userService)
    {
        _userService = userService;
    }

    // Get all doctors
    [HttpGet]
    public async Task<IActionResult> GetDoctors()
    {
        var doctors = await _userService.GetDoctorsAsync();
        return Ok(doctors);
    }

    // Get doctor details by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorDetails(int id)
    {
        var doctor = await _userService.GetDoctorDetailsAsync(id);

        if (doctor == null)
        {
            return NotFound(new { message = "Doctor not found" });
        }

        return Ok(doctor);
    }
    //show profile
     [HttpGet("profile")]
    public async Task<IActionResult> GetDoctorProfile()
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int doctorId))
            return Unauthorized(new { message = "Invalid doctor ID." });

        var doctor = await _userService.GetDoctorProfileAsync(doctorId);
        if (doctor == null)
            return NotFound(new { message = "Doctor not found." });

        return Ok(doctor);
    }



    // Update doctor details by ID
    [HttpPut("Update_profile")]
    public async Task<IActionResult> UpdateDoctorProfile([FromBody] UpdateDoctorProfileDto updatedDoctor)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int doctorId))
            return Unauthorized(new { message = "Invalid doctor ID." });

        var result = await _userService.UpdateDoctorProfileAsync(doctorId, updatedDoctor);

        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }

        return Ok(new { message = "Doctor profile updated successfully" });
    }
}
