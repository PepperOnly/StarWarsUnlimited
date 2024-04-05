namespace CurrencyApiIntegration.Models
{
  public class ExchangeRatesResponse
  {
    public MetaData Meta { get; set; }
    public Dictionary<string, CurrencyData> Data { get; set; }
  }
}
