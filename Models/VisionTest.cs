using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearView.Models;
public class VisionTest
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string TestResult { get; set; }
    public DateTime TestDate { get; set; }
    //Relations
    public User User { get; set; }
}
