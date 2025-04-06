using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearView.Models;
public class Doctor : User
{
    public string? Status { get; set; }
    public int ClinicId { get; set; }
    public int BookingPrice { get; set; }
    public int YearsExperience { get; set; }
    public int MedicalLicenseNumber { get; set; }
    public Clinic Clinic { get; set; }
    public ICollection<User> Patients { get; set; } = new List<User>();
    

}
