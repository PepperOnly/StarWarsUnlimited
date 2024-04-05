using CurrencyApiIntegration.Models;

namespace CurrencyApiIntegration.Core
{
  public interface ICurrencyClient
  {
    public Task<IEnumerable<CurrencyData>> ImportAndUpdateCurrencyInformation();
  }
}
