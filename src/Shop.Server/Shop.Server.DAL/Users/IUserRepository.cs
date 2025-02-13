using Shop.Server.DAL.Core;

namespace Shop.Server.DAL.Users;

public interface IUserRepository : IRepository<User, int>
{
    Task<User?> GetByEmailAsync(string email);
};