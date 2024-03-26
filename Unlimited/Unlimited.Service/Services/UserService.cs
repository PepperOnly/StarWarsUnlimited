using Models;
using Unlimited.Repository.Interfaces;
using Unlimited.Service.Interfaces;

namespace Unlimited.Service.Services
{
  public class UserService : BaseService<User>, IUserService
  {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) : base(userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<User?> GetByAuthenticatedUser(int userId)
    {
      return await _userRepository.GetByAuthenticatedUser(userId);
    }
  }
}
