using Enums;

namespace Unlimited.Api.Requests
{
  public class AddCardToCollectionRequest
  {
    public string Number { get; set; }
    public int Quantity { get; set; }
    public CardSet CardSet { get; set; }
    public CardMake CardMake { get; set; }    
  }
}
