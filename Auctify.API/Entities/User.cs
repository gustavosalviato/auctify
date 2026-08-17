namespace Auctify.API.Entities;

public class User: EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;   
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}