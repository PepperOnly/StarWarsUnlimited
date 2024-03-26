using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Helpers
{
  public class CustomAuthorizeAttribute : TypeFilterAttribute
  {
    public CustomAuthorizeAttribute() : base(typeof(CustomAuthorizationFilter))
    {
    }
  }
}
