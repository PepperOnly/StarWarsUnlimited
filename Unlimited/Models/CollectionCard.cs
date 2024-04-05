using Enums;

namespace Models
{
  public class CollectionCard : BaseModel
  {
    public Guid CardId { get; set; }
    public Guid CollectionId { get; set; }
    public int Quantity { get; set; }
    public decimal? Value { get; set; }


    //Navigation
    public Collection Collection { get; set; }
    public Card Card { get; set; }
  }
}
