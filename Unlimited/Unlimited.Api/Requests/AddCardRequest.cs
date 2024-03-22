using Models;

namespace Unlimited.Api.Requests
{
  /// <summary>
  /// Request object to add new cards to the system
  /// </summary>
  public class AddCardRequest
  {
    /// <summary>
    /// IEnumerable of cards to be added to the system
    /// </summary>
    public required IEnumerable<Card> Cards { get; set; }
  }
}
