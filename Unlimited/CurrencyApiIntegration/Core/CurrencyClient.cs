using ApiHelper.Core;
using CurrencyApiIntegration.Config;
using CurrencyApiIntegration.Helpers;
using CurrencyApiIntegration.Models;
using Microsoft.Extensions.Logging;

namespace CurrencyApiIntegration.Core
{
  public class CurrencyClient : ICurrencyClient
  {
    private readonly IApiClient _iApiClient;
    private readonly ILogger<CurrencyClient> _logger;

    public CurrencyClient(IApiClient iApiClient, ILogger<CurrencyClient> logger)
    {
      _iApiClient = iApiClient;
      _logger = logger;
    }

    public async Task<IEnumerable<CurrencyData>> ImportAndUpdateCurrencyInformation()
    {
      // TODO: Get currency data and return it
      var url = CurrencyApiSettings.BASEURL + CurrencyApiSettings.GET_DATA + CurrencyApiSettings.APIKEY + CurrencyApiSettings.BASE_CURRENCY + CurrencyApiSettings.WANTED_CURRENCIES;

      try
      {
        var currencies = await _iApiClient.GetApiResponseAsync<ExchangeRatesResponse>(url);

        //Map currency
        return CurrencyMapper.MapCurrency(currencies.Data);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Problem Importing Currencies");
        throw new Exception("Problem Importing Currencies", ex);
      }
    }
  }
}
