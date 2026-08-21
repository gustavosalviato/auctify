namespace WorkTree.API.Entities;

public class User : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    
    public Guid TenantId { get; set; }

    public void Touch()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}