using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using ClearView.DTOs;
using ClearView.Services;

[Route("api/appointments")]
[ApiController]
[Authorize]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    public async Task<IActionResult> BookAppointment([FromBody] AppointmentDTO appointmentDto)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Unauthorized();

        var appointment = await _appointmentService.BookAppointmentAsync(userId, appointmentDto);
        return Ok(appointment);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserAppointments()
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Unauthorized();

        var appointments = await _appointmentService.GetUserAppointmentsAsync(userId);
        return Ok(appointments);
    }


    [HttpGet("doctor")]
    public async Task<IActionResult> GetDoctorAppointments()
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int doctorId))
            return Unauthorized();

        var appointments = await _appointmentService.GetDoctorAppointmentsAsync(doctorId);
        return Ok(appointments);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(int id, [FromBody] UpdateAppointmentDTO updateDto)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Unauthorized();

        var updatedAppointment = await _appointmentService.UpdateAppointmentAsync(id, userId, updateDto);
        if (updatedAppointment == null)
            return NotFound(new { message = "Appointment not found or not authorized." });

        return Ok(updatedAppointment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelAppointment(int id)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Unauthorized();

        var success = await _appointmentService.CancelAppointmentAsync(id, userId);
        if (!success)
            return NotFound(new { message = "Appointment not found or not authorized." });

        return Ok(new { message = "Appointment cancelled successfully." });
    }


}
