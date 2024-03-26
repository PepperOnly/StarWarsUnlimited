using ApiAuth.Helpers;
using ApiAuth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Unlimited.Api
{
  public static class AuthenticationLoader
  {
    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
      var authenticationSettings = new AuthenticationSettings();
      configuration.GetSection("AuthenticationSettings").Bind(authenticationSettings);
      

      if (authenticationSettings.AuthenticationEnabled)
      {
        // Register the authentication settings for dependency injection
        services.AddSingleton(authenticationSettings);

        //// Add authentication services here, such as JWT authentication
        //services.AddAuthentication(options =>
        //{
        //  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //})
        //.AddJwtBearer(options =>
        //{
        //  // Configure JWT authentication options
        //});
      }
    }

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
