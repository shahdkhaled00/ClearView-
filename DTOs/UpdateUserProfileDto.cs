namespace ClearView.DTOs;
public class UpdateUserProfileDto
{
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public int? CityId { get; set; }
    public int? CountryId { get; set; }
}