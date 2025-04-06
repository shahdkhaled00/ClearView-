using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearView.Models;
public class Clinic
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string ContactInfo { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
}