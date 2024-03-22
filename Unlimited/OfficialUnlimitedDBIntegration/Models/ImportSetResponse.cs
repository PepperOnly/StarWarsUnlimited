namespace OfficialUnlimitedDBIntegration.Models
{
  public class ImportSetResponse
  {
    public int Total_Cards { get; set; }
    public IEnumerable<ImportedCard> Data { get; set; }
  }
}
