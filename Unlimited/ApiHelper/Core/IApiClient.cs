namespace ApiHelper.Core
{
  public interface IApiClient
  {
    Task<TResponse> GetApiResponseAsync<TResponse>(string baseUrl);
  }
}
