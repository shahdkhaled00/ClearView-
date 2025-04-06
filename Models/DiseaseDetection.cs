using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearView.Models;
public class DiseaseDetection
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string RetinalScan { get; set; }
    public string DiseaseType { get; set; }
    public string DetectionResult { get; set; }
    public DateTime TestDate { get; set; }
    //Realations
    public User User { get; set; }
}