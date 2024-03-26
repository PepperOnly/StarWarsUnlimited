using ApiAuth.Interfaces;
using ApiAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ApiAuth.Helpers
{
  public class JwtMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly AuthenticationSettings _appSettingsAuth;
    private readonly ILogger<JwtMiddleware> _logger;

    public JwtMiddleware(RequestDelegate next, IOptions<AuthenticationSettings> appSettings, ILogger<JwtMiddleware> logger)
    {
      _next = next;
      _appSettingsAuth = appSettings.Value;
      _logger = logger;
    }

    public async Task Invoke(HttpContext context, IUserAuthService userService)
    {
      var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

      if (token != null)
        await attachUserToContext(context, userService, token);

      await _next(context);
    }

    private async Task attachUserToContext(HttpContext context, IUserAuthService userService, string token)
    {
      try
      {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettingsAuth.Secret);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
          // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
          ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

        //Attach user to context on successful JWT validation
        context.Items["User"] = await userService.GetById(userId);
      }
      catch(Exception ex)
      {
        //Do nothing if JWT validation fails
        // user is not attached to context so the request won't have access to secure routes
        _logger.LogError(ex, "Error JWT Tokens");
      }
    }
  }
}
