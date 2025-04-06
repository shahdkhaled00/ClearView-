namespace ClearView.DTOs;
public class UserProfileDto
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string ContactInfo { get; set; }
    public string Gender { get; set; }  
    public int? Age { get; set; }
    public int? CityId { get; set; }
    public int? CountryId { get; set; }
}