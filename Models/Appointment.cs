using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearView.Models;
public class Appointment
{
    [Key]
    public int Id { get; set; }
    public string? Type { get; set; }

    public int UserId { get; set; }
    [Required]
    public int DoctorId { get; set; }
    public DateTime Time { get; set; }
    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "Pending"; // Default status

    public string? Evaluation { get; set; }
    //Relations
    public User User { get; set; }
    public Doctor Doctor { get; set; }

}