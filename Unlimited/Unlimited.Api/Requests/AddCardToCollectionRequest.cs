using Enums;
using Models;

namespace Unlimited.Api.Requests
{
  public class AddCardToCollectionRequest
  {
    public AddCardToCollectionRequest()
    {
      Card = new CollectionCard();
    }

    public CollectionCard Card { get; set; }
  }
}
