using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
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
    [HttpGet]
    public Task<IActionResult> GetCards()
    {
      try
      {
        // Implement your logic here        
        return (Task<IActionResult>)_cardService.GetCards();
      }
      catch (Exception ex)
      {
        // Log the exception
        return null;
      }
    }
  }
}