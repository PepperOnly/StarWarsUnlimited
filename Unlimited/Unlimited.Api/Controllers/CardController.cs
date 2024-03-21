using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Models;
using Unlimited.Api.Requests;
using Unlimited.Service.Interfaces;

namespace Unlimited.Api.Controllers
{
  /// <summary>
  /// Card Controller to do basic crud operations on cards to get them into the sytem.
  /// </summary>
  [ApiVersion(1)]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  public class CardController : ControllerBase
  {
    /// <summary>
    /// Service to interact with cards within the system
    /// </summary>
    public readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
      _cardService = cardService;
    }

    /// <summary>
    /// Get Cards from the system
    /// </summary>
    /// <returns>Card/s</returns> 
    [MapToApiVersion(1)]
    [HttpPost]
    public async Task<IActionResult> AddCard(AddCardRequest request)
    {
      try
      {        
        var result = await _cardService.AddCardAsync(request.Cards); 

        if (result)
        {
          return Ok(result); // Return 200 OK with the added card/s
        }
        else
        {
          return BadRequest("Failed to add card"); // Return 400 Bad Request if the card was not added successfully
        }
      }
      catch (Exception ex)
      {
        // Log the exception
        return StatusCode(500, "Internal server error"); // Return 500 Internal Server Error for any unhandled exception
      }
    }
  }
}