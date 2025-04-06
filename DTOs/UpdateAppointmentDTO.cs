namespace ClearView.DTOs
{
    public class UpdateAppointmentDTO
    {
        public DateTime Time { get; set; }
        public string? Evaluation { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
    }
}
