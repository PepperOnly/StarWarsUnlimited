using Models;

namespace Unlimited.Api.Requests
{
  /// <summary>
  /// Request Object for adding cards to your collection
  /// </summary>
  public class AddCardToCollectionRequest
  {
    public AddCardToCollectionRequest() 
    {
      Cards = new Dictionary<Card, int>();
    }
    /// <summary>
    /// Dictionary for adding cards to your collection, contains card object as well as volume to be added
    /// </summary>
    public Dictionary<Card,int> Cards { get; set; }
  }
}
