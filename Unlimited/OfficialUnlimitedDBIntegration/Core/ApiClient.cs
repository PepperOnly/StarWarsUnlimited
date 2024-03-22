using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace OfficialUnlimitedDBIntegration.Core
{
  public class ApiClient : IApiClient
  {
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiClient> _logger;

    public ApiClient(ILogger<ApiClient> logger)
    {      
      _httpClient = new HttpClient();
      _logger = logger;
    }
    public async Task<TResponse> GetApiResponseAsync<TResponse>(string baseUrl)
    {
      try
      {
        HttpResponseMessage response = await _httpClient.GetAsync(baseUrl);

        if (response.IsSuccessStatusCode)
        {
          string responseData = await response.Content.ReadAsStringAsync();
          TResponse responseObject = JsonConvert.DeserializeObject<TResponse>(responseData);
          return responseObject;
        }
        else
        {
          // If the response is not successful, handle the error here
          _logger.LogError($"API request failed with status code: {response.StatusCode}");
          throw new HttpRequestException($"API request failed with status code: {response.StatusCode}");
        }
      }
      catch (Exception ex)
      {
        // Handle exceptions
        _logger.LogError(ex, "An error occurred while calling https://api.swu-db.com.");
        throw new Exception("An error occurred while calling https://api.swu-db.com.", ex);
      }
    }
  }
}
