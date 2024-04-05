using Models;

namespace Unlimited.Service.Interfaces
{
  public interface ICurrencyService : IBaseService<CurrencyData>
  {
    public Task ImportAndUpdateCurrency();
  }
}
