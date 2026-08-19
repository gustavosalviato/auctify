using Auctify.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auctify.API.Infra;

public class AuctifyDbContext : DbContext
{
    public AuctifyDbContext(DbContextOptions options) : base(options)
    {
    }
    
     public DbSet<User> Users { get; set; }


}
