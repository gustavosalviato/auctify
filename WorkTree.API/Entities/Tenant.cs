namespace WorkTree.API.Entities;

public class Tenant : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<User> Users { get; set; }

    public void Touch()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}