using Microsoft.EntityFrameworkCore;
using Shop.Server.DAL.Core;

namespace Shop.Server.DAL.Users;

public sealed class UserRepository(ApplicationDbContext dbContext)
    : Repository<User, int>(dbContext), IUserRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Set<User>()
            .FirstOrDefaultAsync(user => user.Email == email);
    }
}