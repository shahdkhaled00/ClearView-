using System.ComponentModel.DataAnnotations;

namespace ClearView.DTOs
{
    public class RegisterDoctorModel : RegisterUserModel
    {
        [Required]
        public int ClinicId { get; set; }

        [Required]
        public int BookingPrice { get; set; }

        [Required]
        public int YearsExperience { get; set; }

        [Required]
        public int MedicalLicenseNumber { get; set; }
    }
}
