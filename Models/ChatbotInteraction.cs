using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearView.Models;
public class ChatbotInteraction
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Message { get; set; }
    public string Response { get; set; }
    public string History { get; set; }
    //relations
    public User User { get; set; }
}