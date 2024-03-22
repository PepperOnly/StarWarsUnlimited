using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Unlimited.Api.Controllers
{
  /// <summary>
  /// Collection Controller to manage my collection of cards.
  /// </summary>
  [ApiVersion(1)]
  [Route("api/v{version:apiVersion}/[controller]/[action]")]
  [ApiController]
  public class CollectionController : ControllerBase
  {
    public readonly ILogger<CardController> _logger;

    public CollectionController(ILogger<CardController> logger)
    {
      _logger = logger;
    }
  }
}
