using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCrypt.Net;

namespace ClearView.Models;

public class User
{
    [Key] public int Id { get; set; }
    [MinLength(3)]
    public string Name { get; set; }

    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public int? Age { get; set; }
    public string? Gender { get; set; }
    public string? ContactInfo { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Street { get; set; }
    public string? ResetPasswordToken { get; set; }
    public DateTime? ResetPasswordTokenExpiry { get; set; }

    public int CityId { get; set; }
    public int CountryId { get; set; }
    public int? DoctorId { get; set; } 
    public Doctor? AssignedDoctor { get; set; } 
    public City City { get; set; }
    public Country Country { get; set; }
    public ICollection<VisionTest> VisionTests { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<ChatbotInteraction> ChatbotInteractions { get; set; }
    public ICollection<DiseaseDetection> DiseaseDetections { get; set; }

public void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
}