using Auctify.API.Entities;

namespace Auctify.API.Contracts;

public interface IUserRepository
{
    void Create(User user);
    User? FindByEmail(string email);
}