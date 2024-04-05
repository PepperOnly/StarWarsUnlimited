using CurrencyApiIntegration.Models;

namespace CurrencyApiIntegration.Helpers
{
  public class CurrencyMapper
  {
    public static IEnumerable<CurrencyData> MapCurrency(Dictionary<string, CurrencyData> data)
    {
      List<CurrencyData> currencies = new List<CurrencyData>();

      foreach (var kvp in data)
      {
        currencies.Add(new CurrencyData
        {
          Code = kvp.Key,
          Value = kvp.Value.Value          
        });
      }

      return currencies;
    }
  }
}
