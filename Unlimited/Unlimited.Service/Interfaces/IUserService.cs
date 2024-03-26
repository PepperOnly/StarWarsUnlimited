using Models;

namespace Unlimited.Service.Interfaces
{
  public interface IUserService : IBaseService<User>
  {
    public Task<User?> GetByAuthenticatedUser(int userId);
  }
}
