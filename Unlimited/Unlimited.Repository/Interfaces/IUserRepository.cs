using Models;

namespace Unlimited.Repository.Interfaces
{
  public interface IUserRepository : IBaseRepository<User>
  {
    Task<User?> GetByAuthenticatedUser(int userId);
  }
}
