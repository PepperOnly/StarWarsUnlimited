using FinancialHelper.Enums;

namespace FinancialHelper.Interfaces
{
  public interface IFinancialHelper
  {
    public Task<double> CurrencyConvert(Currency fromCurrency, Currency toCurrency, double ammount);
  }
}
