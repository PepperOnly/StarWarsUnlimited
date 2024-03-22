namespace Models
{
  public class Collection : BaseModel
  {
    public Collection()
    {
      Cards = new List<CollectionCard>();
    }

    public User Owner { get; set; }
    public List<CollectionCard> Cards { get; set; }
  }
}
