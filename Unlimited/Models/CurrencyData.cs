namespace Models
{
  public class CurrencyData : BaseModel
  {
    public string Code { get; set; }
    public decimal Value { get; set; }
    public DateTime? Updated { get; set; }
  }
}
