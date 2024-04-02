using ApiAuth.Helpers;

namespace Unlimited.Api
{
  public static class AuthenticationLoader
  {
    public static void UseAuthMiddleware(this IApplicationBuilder app, IConfiguration configuration)
    {
      var authenticationEnabled = configuration.GetValue<bool>("AuthenticationSettings:AuthenticationEnabled");

      if (authenticationEnabled)
      {
        // Enable authentication middleware
        app.UseMiddleware<JwtMiddleware>();        
        app.UseAuthorization();
        app.UseAuthentication();
       }
    }
  }
}
