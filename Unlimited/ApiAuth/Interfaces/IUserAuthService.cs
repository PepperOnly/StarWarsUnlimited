using ApiAuth.Models;

namespace ApiAuth.Interfaces
{
  public interface IUserAuthService
  {
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
    Task<IEnumerable<UserAuth>> GetAll();
    Task<UserAuth?> GetById(int id);
    Task<UserAuth?> AddAndUpdateUser(UserAuth userObj);
  }
}
