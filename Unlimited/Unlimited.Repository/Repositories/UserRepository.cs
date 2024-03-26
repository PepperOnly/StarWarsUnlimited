using Microsoft.EntityFrameworkCore;
using Models;
using Unlimited.Repository.Interfaces;

namespace Unlimited.Repository.Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    private readonly UnlimitedDbContext _dbContext;

    public UserRepository(UnlimitedDbContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<User?> GetByAuthenticatedUser(int userId)
    {
      return await _dbContext.Users.FirstOrDefaultAsync(x => x.Auth.Id == userId);
    }
  }
}
