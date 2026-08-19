using Auctify.API.Contracts;
using Auctify.API.Entities;

namespace Auctify.API.Infra.Repositories;

public class UsersRepository : IUserRepository
{
    private readonly AuctifyDbContext _context;

    public UsersRepository(AuctifyDbContext context) => _context = context;

    public void Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public User? FindByEmail(string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        return user;
    }

    public User? FindById(Guid id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        return user;
    }
}