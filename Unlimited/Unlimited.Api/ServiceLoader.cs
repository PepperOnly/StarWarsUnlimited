using ApiAuth.Interfaces;
using ApiAuth.Services;
using ApiHelper.Core;
using CurrencyApiIntegration.Core;
using OfficialUnlimitedDBIntegration.Core;
using Unlimited.Repository.Interfaces;
using Unlimited.Repository.Repositories;
using Unlimited.Service.Interfaces;
using Unlimited.Service.Services;

namespace Unlimited.Api
{
  public static class ServiceLoader
  {
    public static void AddCustomIntegrations(this IServiceCollection services)
    {
      services.AddScoped<IApiClient, ApiClient>();
      services.AddScoped<IUnlimitedClient, UnlimitedClient>();
      services.AddScoped<ICurrencyClient, CurrencyClient>();
      services.AddScoped<IUserAuthService, UserAuthService>();
      services.AddScoped<IAuthorizationSettingsService, AuthorizationSettingsService>();
    }

    public static void AddCustomServices(this IServiceCollection services)
    {
      services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
      services.AddScoped<ICardService, CardService>();
      services.AddScoped<ICollectionService, CollectionService>();
      services.AddScoped<ICurrencyService, CurrencyService>();
      services.AddScoped<IUserService, UserService>();
    }

    public static void AddCustomRepositories(this IServiceCollection services)
    {
      services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
      services.AddScoped<ICardRepository, CardRepository>();
      services.AddScoped<ICollectionRepository, CollectionRepository>();
      services.AddScoped<ICurrencyRepository, CurrencyRepository>();
      services.AddScoped<IUserRepository, UserRepository>();
    }
  }
}
