using Enums;

namespace Unlimited.Api.Requests
{
  public class UpdateCardInCollectionRequest
  {
    public string Number { get; set; }
    public CardSet CardSet { get; set; }  
    public int QuantityToAdd { get; set; }
  }
}
