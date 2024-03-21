namespace OfficialUnlimitedDBIntegration.Models
{
  public class ImportedCard
  {
    public string Set { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public string Subtitle { get; set; } // Optional field
    public string Type { get; set; }
    public List<string> Aspects { get; set; }
    public List<string> Traits { get; set; }
    public List<string> Arenas { get; set; }
    public string Cost { get; set; }
    public string Power { get; set; }
    public string HP { get; set; }
    public string FrontText { get; set; }
    public string EpicAction { get; set; }
    public bool DoubleSided { get; set; }
    public string BackText { get; set; }
    public string Rarity { get; set; }
    public bool Unique { get; set; }
    public List<string> Keywords { get; set; }
    public string Artist { get; set; }
    public string FrontArt { get; set; }
    public string BackArt { get; set; }
  }
}
