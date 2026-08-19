using Auctify.API.Entities;

namespace Auctify.API.Contracts;

public interface IUserRepository
{
    void Create(User user);
    void Update(User user);
    User? FindByEmail(string email);
    User? FindById(Guid id);
}