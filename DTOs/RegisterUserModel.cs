using System.ComponentModel.DataAnnotations;

namespace ClearView.DTOs
{
    public class RegisterUserModel
    {
        [Required, MinLength(3)]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, MinLength(8)]
        public string Password{ get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? ContactInfo { get; set; }
    }
}
