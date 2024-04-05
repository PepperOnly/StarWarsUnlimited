using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Unlimited.Service.Interfaces;

namespace Unlimited.Api.Controllers
{
  /// <summary>
  /// Financial Controller to manage Financial Information such as currencies etc
  /// </summary>
  [ApiVersion(1)]
  [Route("api/v{version:apiVersion}/[controller]/[action]")]
  [ApiController]
  public class FinancialController : ControllerBase
  {
    private readonly ICurrencyService _currencyService;
    private readonly ILogger<CardController> _logger;

    public FinancialController(ILogger<CardController> logger, ICurrencyService currencyService)
    {
      _currencyService = currencyService;
      _logger = logger;
    }

    [MapToApiVersion(1)]
    [HttpGet]
    public async Task<IActionResult> GetCurrencies()
    {
      try
      {
        var result = await _currencyService.GetAll();
        return Ok(result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error getting currencies");
        return StatusCode(500, "Internal server error");
      }
    }

    [MapToApiVersion(1)]
    [HttpPost]
    public async Task<IActionResult> ImportAndUpdateCurrencies()
    {
      try
      {
        await _currencyService.ImportAndUpdateCurrency();

        return Ok("Currencies updated successfully.");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error updating currencies.");
        return StatusCode(500, "Internal server error.");
      }
    }
  }
}
