using ApiAuth.Interfaces;
using ApiAuth.Services;
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
      services.AddScoped<IUserAuthService, UserAuthService>();
    }

    public static void AddCustomServices(this IServiceCollection services)
    {
      services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
      services.AddScoped<ICardService, CardService>();
      services.AddScoped<ICollectionService, CollectionService>();
    }

    public static void AddCustomRepositories(this IServiceCollection services)
    {
      services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
      services.AddScoped<ICardRepository, CardRepository>();
      services.AddScoped<ICollectionRepository, CollectionRepository>();
    }
  }
}
