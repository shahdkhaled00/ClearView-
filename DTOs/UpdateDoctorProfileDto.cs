namespace ClearView.DTOs;
public class UpdateDoctorProfileDto : UpdateUserProfileDto
{
    public int? Age { get; set; }
    public string Gender { get; set; }
    public int? YearsExperience { get; set; }
    public int? BookingPrice { get; set; }
    public int? MedicalLicenseNumber { get; set; }
    public int? ClinicId { get; set; }
}
