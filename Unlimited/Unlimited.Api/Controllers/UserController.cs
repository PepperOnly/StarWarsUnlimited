using ApiAuth.Interfaces;
using ApiAuth.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Unlimited.Service.Interfaces;

namespace Unlimited.Api.Controllers
{
  [ApiVersion(1)]
  [Route("api/v{version:apiVersion}/[controller]/[action]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserAuthService _userAuthService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserAuthService userAuthService, ILogger<UserController> logger)
    {
      _userAuthService = userAuthService;
      _logger = logger;
    }

    [MapToApiVersion(1)]
    [HttpPost]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
      var response = await _userAuthService.Authenticate(model);

      if (response == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      return Ok(response);
    }

  }
}
