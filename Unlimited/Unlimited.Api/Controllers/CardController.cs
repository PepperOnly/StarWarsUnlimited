using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Models;
using Unlimited.Api.Requests;
using Unlimited.Service.Interfaces;

namespace Unlimited.Api.Controllers
{
  /// <summary>
  /// Card Controller to do basic crud operations on cards to get them into the system.
  /// </summary>
  [ApiVersion(1)]
  [Route("api/v{version:apiVersion}/[controller]/[action]")]
  [ApiController]
  public class CardController : ControllerBase
  {    
    public readonly ICardService _cardService;
    public readonly ILogger<CardController> _logger;

    public CardController(ICardService cardService, ILogger<CardController> logger)
    {
      _cardService = cardService;
      _logger = logger;
    }

    /// <summary>
    /// Adds card/s to the system.
    /// </summary>
    /// <returns>Message</returns> 
    [MapToApiVersion(1)]
    [HttpPost]
    public async Task<IActionResult> AddCard(AddCardRequest request)
    {
      try
      {
        var cardsAdded = await _cardService.AddCardAsync(request.Cards);
        return Ok($"{cardsAdded} cards added successfully");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error adding cards");
        return StatusCode(500, "Internal server error");
      }
    }

    /// <summary>
    /// Imports cards into the system by set
    /// </summary>
    /// <param name="request">Set you want to import</param>
    /// <returns>Message</returns>
    [MapToApiVersion(1)]
    [HttpPost]
    public async Task<IActionResult> AddCardSet(AddCardSet request)
    {
      try
      {
        var importedCards = await _cardService.ImportCardsBySet(request.Set);
        return Ok($"{importedCards} Cards added successfully");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Error importing cards, set: {request.Set}");
        return StatusCode(500, $"Error importing cards, set: {request.Set}");
      }
    }

    /// <summary>
    /// Returns all cards in the system.
    /// </summary>
    /// <returns>Cards</returns>
    [MapToApiVersion(1)]
    [HttpGet]
    public async Task<IActionResult> GetAllCards()
    {
      try
      {
        var result = await _cardService.GetCardsAsync();
        return Ok(result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error adding cards");
        return StatusCode(500, "Internal server error");
      }
    }
  }
}