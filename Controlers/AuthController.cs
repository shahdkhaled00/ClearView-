using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ClearView.DTOs;
using ClearView.Services;
using Microsoft.EntityFrameworkCore;

namespace ClearView.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;


        public AuthController(IUserService userService)
        {
            _userService = userService;


        }

        // Register User
        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _userService.IsUserNameTakenAsync(model.Username))
            {
                return BadRequest(new { error = "Username is already taken, try another one" });
            }

            var result = await _userService.RegisterUserAsync(model);
            if (!result.Success)
                return BadRequest(new { error = result.Message });

            return Ok(new { message = "User registered successfully", userId = result.UserId });
        }

        // Register Doctor
        [HttpPost("register-doctor")]
        public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _userService.IsUserNameTakenAsync(model.Username))
            {
                return BadRequest(new { error = "Username is already taken, try another one!" });
            }

            var result = await _userService.RegisterDoctorAsync(model);
            if (!result.Success)
                return BadRequest(new { error = result.Message });

            return Ok(new { message = "Doctor registered successfully", doctorId = result.UserId });
        }
        // get countries
        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _userService.GetCountriesAsync();
            return Ok(countries);
        }

        // get cities
        [HttpGet("cities/{countryId}")]
        public async Task<IActionResult> GetCities(int countryId)
        {
            var cities = await _userService.GetCitiesByCountryAsync(countryId);
            return Ok(cities);
        }
        // get clinics

        [HttpGet("clinics-by-country/{countryId}")]
        public async Task<IActionResult> GetClinicsByCountry(int countryId)
        {
            var clinics = await _userService.GetClinicsByCountryAsync(countryId);
            
            if (clinics == null || clinics.Count == 0)
                return NotFound(new { message = "No clinics found for this country." });

            return Ok(clinics);
        }



        // Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.LoginAsync(model);
            if (!result.Success)
                return Unauthorized(new { error = result.Message });

            return Ok(new { message = "Login successful", token = result.Token, userId = result.UserId });
        }
        // Forgot Password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.ForgotPasswordAsync(model.Email);
            if (!result.Success)
                return BadRequest(new { error = result.Message });

            return Ok(new { message = "Password reset code has been sent to your email." });
        }

        // Reset Password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.ResetPasswordAsync(model.Email, model.Code, model.NewPassword);

            if (!result.Success)
                return BadRequest(new { error = result.Message });

            return Ok(new { message = "Password has been reset successfully." });
        }



    }
}