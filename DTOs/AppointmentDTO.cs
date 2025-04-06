namespace ClearView.DTOs
{
    public class AppointmentDTO
    {
        public int DoctorId { get; set; }
        public DateTime Time { get; set; }
        public string? Evaluation { get; set; }
        public string? Type { get; set; }
    }

    public class AppointmentResponseDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
        public string? Evaluation { get; set; }
        public string? Type { get; set; }
    }
}
