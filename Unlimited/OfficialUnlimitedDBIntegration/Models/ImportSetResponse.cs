namespace OfficialUnlimitedDBIntegration.Models
{
  public class ImportSetResponse
  {
    public int TotalCards { get; set; }
    public IEnumerable<ImportedCard> Data { get; set; }
  }
}
