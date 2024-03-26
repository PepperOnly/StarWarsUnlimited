using ApiAuth.Interfaces;
using ApiAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiAuth.Helpers
{
  public class CustomAuthorizationFilter : IAuthorizationFilter
  {
    private readonly IAuthorizationSettingsService _authorizationSettingsService;

    public CustomAuthorizationFilter(IAuthorizationSettingsService authorizationSettingsService)
    {
      _authorizationSettingsService = authorizationSettingsService;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
      var authorizationEnabled = _authorizationSettingsService.IsAuthorizationEnabled();

      if (!authorizationEnabled)
      {
        // Authorization is disabled, allow access
        return;
      }

      var user = (UserAuth?)context.HttpContext.Items["User"];
      if (user == null)
      {
        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
      }
    }
  }
}
