using ApiAuth.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ApiAuth.Services
{
  public class AuthorizationSettingsService : IAuthorizationSettingsService
  {
    private readonly IConfiguration _configuration;

    public AuthorizationSettingsService(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public bool IsAuthorizationEnabled()
    {
      return _configuration.GetValue<bool>("AuthenticationSettings:AuthenticationEnabled");
    }
  }
}
