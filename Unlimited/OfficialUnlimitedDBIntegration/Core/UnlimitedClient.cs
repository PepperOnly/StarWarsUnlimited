using ApiHelper.Core;
using Microsoft.Extensions.Logging;
using Models;
using OfficialUnlimitedDBIntegration.Config;
using OfficialUnlimitedDBIntegration.Helpers;
using OfficialUnlimitedDBIntegration.Models;

namespace OfficialUnlimitedDBIntegration.Core
{
  public class UnlimitedClient : IUnlimitedClient
  {
    private readonly IApiClient _iApiClient;
    private readonly ILogger<UnlimitedClient> _logger;

    public UnlimitedClient(IApiClient iApiClient, ILogger<UnlimitedClient> logger)
    {
      _iApiClient = iApiClient;
      _logger = logger;
    }

    public async Task<IEnumerable<Card>> GetCardSet(string set)
    {
      // TODO: Get cards from star wars unlimted DB and return them in a format we understand.
      var url = UnlimitedDBApiUrls.BASEURL + UnlimitedDBApiUrls.CARDS + set;

      try
      {
        var cards = await _iApiClient.GetApiResponseAsync<ImportSetResponse>(url);
        //Map cards
        return CardMapper.MapToCard(cards.Data);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Problem Importing cards");
        throw new Exception("Problem Importing cards", ex);
      }      
    }
  }
}
