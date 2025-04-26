using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User usuario)
    {
        _dbContext.Users.Add(usuario);
        await _dbContext.SaveChangesAsync();
    }
}
