using Enums;

namespace Models
{
  public class CollectionCard : BaseModel
  {
    public CollectionCard()
    {
      Card = new Card();
    }

    public Card Card { get; set; }
    public int Quantity { get; set; }
    public decimal? Value { get; set; }
    public CardMake CardMake { get; set; }
  }
}
