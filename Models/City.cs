using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClearView.Models;
public class City
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
}