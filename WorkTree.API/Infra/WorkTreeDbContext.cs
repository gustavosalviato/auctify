using Microsoft.EntityFrameworkCore;
using WorkTree.API.Entities;

namespace WorkTree.API.Infra;

public class WorkTreeDbContext : DbContext
{
    public WorkTreeDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}