using ApiAuth.Helpers;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Unlimited.Api.Requests;
using Unlimited.Service.Interfaces;

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
    private readonly ICollectionService _collectionService;
    private readonly ILogger<CardController> _logger;

    public CollectionController(ICollectionService collectionService, ILogger<CardController> logger)
    {
      _collectionService = collectionService;
      _logger = logger;
    }


    /// <summary>
    /// Adds specified card to Collection
    /// </summary>
    /// <returns></returns>
    [MapToApiVersion(1)]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddCardToMyCollection(AddCardToCollectionRequest request)
    {
      try
      {
        //ToDO: AUTHENTICATION...
        //await _collectionService.AddCardToMyCollectionAsync(request.Card);
        return Ok($"Card added successfully");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error adding cards");
        return StatusCode(500, "Internal server error");
      }
    }
  }
}
