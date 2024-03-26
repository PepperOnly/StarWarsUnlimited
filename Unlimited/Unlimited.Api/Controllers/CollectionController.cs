using ApiAuth.Helpers;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
    private readonly IUserService _userService;
    private readonly ILogger<CardController> _logger;

    public CollectionController(ICollectionService collectionService, IUserService userService, ILogger<CardController> logger)
    {
      _collectionService = collectionService;
      _userService = userService;
      _logger = logger;
    }


    /// <summary>
    /// Adds a specified card to the authenticated user's collection.
    /// </summary>
    /// <param name="request">The request containing card details to be added.</param>
    /// <returns>Returns IActionResult indicating the result of the operation.</returns>
    [MapToApiVersion(1)]
    [HttpPost]
    [CustomAuthorize]
    public async Task<IActionResult> AddCardToMyCollection(AddCardToCollectionRequest request)
    {
      try
      {
        // Extract the user ID from the JWT claims
        var loggedInUserId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        // Retrieve the user from the system database using the identifier
        var appUser = await _userService.GetByAuthenticatedUser(loggedInUserId);

        if (appUser == null)
        {
          // If user not found, return unauthorized status
          return Unauthorized();
        }

        // Get the collection ID of the authenticated user
        var collectionId = await _collectionService.GetCollectionIdByUserId(appUser.Id);

        // Add the card to the user's collection
        var result = await _collectionService.AddCardToCollection(appUser.Id, collectionId,
                                                                  request.Number, (int)request.CardSet,
                                                                  (int)request.CardType, request.Quantity);

        if (result)
        {
          // Return success message if card added successfully
          return Ok($"Card added successfully");
        }
        else
        {
          // Return error message if card addition failed
          return BadRequest("Failed to add card to collection");
        }
      }
      catch (FormatException ex)
      {
        // Handle format exception (e.g., invalid user ID)
        _logger.LogError(ex, "Error parsing user ID");
        return BadRequest("Invalid user ID format");
      }
      catch (Exception ex)
      {
        // Handle other exceptions
        _logger.LogError(ex, "Error adding cards");
        return StatusCode(500, "Internal server error");
      }
    }
  }
}
