using ApiAuth.Interfaces;
using ApiAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAuth.Services
{
  public class UserAuthService : IUserAuthService
  {
    private readonly AppSettingsAuth _appSettingsAuth;
    private readonly AuthDbContext _authDbContext;

    public UserAuthService(IOptions<AppSettingsAuth> appSettings, AuthDbContext _db)
    {
      _appSettingsAuth = appSettings.Value;
      _authDbContext = _db;
    }

    public async Task<UserAuth?> AddAndUpdateUser(UserAuth userObj)
    {
      bool isSuccess = false;
      if (userObj.Id > 0)
      {
        var obj = await _authDbContext.UserAuthorization.FirstOrDefaultAsync(c => c.Id == userObj.Id);
        if (obj != null)
        {
          // obj.Address = userObj.Address;
          obj.FirstName = userObj.FirstName;
          obj.LastName = userObj.LastName;
          _authDbContext.UserAuthorization.Update(obj);
          isSuccess = await _authDbContext.SaveChangesAsync() > 0;
        }
      }
      else
      {
        await _authDbContext.UserAuthorization.AddAsync(userObj);
        isSuccess = await _authDbContext.SaveChangesAsync() > 0;
      }

      return isSuccess ? userObj : null;
    }

    public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
    {
      var user = await _authDbContext.UserAuthorization.SingleOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

      // return null if user not found
      if (user == null) return null;

      // authentication successful so generate jwt token
      var token = await generateJwtToken(user);

      return new AuthenticateResponse(user, token);
    }

    public async Task<IEnumerable<UserAuth>> GetAll()
    {
      return await _authDbContext.UserAuthorization.Where(x => x.isActive == true).ToListAsync();
    }

    public async Task<UserAuth?> GetById(int id)
    {
      return await _authDbContext.UserAuthorization.FirstOrDefaultAsync(x => x.Id == id);
    }

    // helper methods
    private async Task<string> generateJwtToken(UserAuth user)
    {
      //Generate token that is valid for 7 days
      var tokenHandler = new JwtSecurityTokenHandler();
      var token = await Task.Run(() =>
      {

        var key = Encoding.ASCII.GetBytes(_appSettingsAuth.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
          Expires = DateTime.UtcNow.AddDays(7),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        return tokenHandler.CreateToken(tokenDescriptor);
      });

      return tokenHandler.WriteToken(token);
    }
  }
}
