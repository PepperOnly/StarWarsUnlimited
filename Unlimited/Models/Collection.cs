namespace Models
{
  public class Collection : BaseModel
  {
    public Collection()
    {
      Cards = new List<CollectionCard>();
    }

    public Guid UserId { get; set; }

    //Navigation
    public List<CollectionCard> Cards { get; set; }
  }
}
