using CurrencyApiIntegration.Core;
using Models;
using Unlimited.Repository.Interfaces;
using Unlimited.Service.Interfaces;

namespace Unlimited.Service.Services
{
  public class CurrencyService : BaseService<CurrencyData>, ICurrencyService
  {
    private readonly ICurrencyRepository _currencyRepository;
    private readonly ICurrencyClient _currencyClient;

    public CurrencyService(ICurrencyRepository currencyRepository, ICurrencyClient currencyClient) : base(currencyRepository)
    {
      _currencyRepository = currencyRepository;
      _currencyClient = currencyClient;
    }

    public async Task ImportAndUpdateCurrency()
    {
      // Get currency data
      var currencies = await _currencyClient.ImportAndUpdateCurrencyInformation();
      var currencyData = currencies.ToList();

      // Get existing currencies from repository
      var existingCurrencies = (await _currencyRepository.GetAll()).ToList();

      // Update existing currencies and prepare new currencies to add
      var currenciesToAdd = new List<CurrencyData>();
      foreach (var currency in currencyData)
      {
        var existingCurrency = existingCurrencies.FirstOrDefault(x => x.Code == currency.Code);
        if (existingCurrency != null)
        {
          // Update existing currency
          existingCurrency.Value = currency.Value;
          existingCurrency.Updated = DateTime.UtcNow;
        }
        else
        {
          // Add new currency
          currenciesToAdd.Add(new CurrencyData { Code = currency.Code, Value = currency.Value, Updated = DateTime.UtcNow });
        }
      }

      // Add new currencies and update existing ones in batch
      await _currencyRepository.AddRange(currenciesToAdd);
      await _currencyRepository.UpdateRange(existingCurrencies);
    }
  }
}
