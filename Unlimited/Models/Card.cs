using Enums;
using System.ComponentModel.DataAnnotations;

namespace Models
{
  public class Card : BaseModel
  {
    public Card()
    {
      Aspects = new List<CardAspect>();
      Traits = new List<CardTrait>();
      Arenas = new List<CardArena>();
      Keywords = new List<CardKeyword>();
    }
   
    public CardSet Set { get; set; }    
    public string Number { get; set; }
    public string Name { get; set; }
    public string Subtitle { get; set; }
    public CardType Type { get; set; }
    public List<CardAspect>? Aspects { get; set; }
    public List<CardTrait> Traits { get; set; }
    public List<CardArena> Arenas { get; set; }
    public string Cost { get; set; }
    public string Power { get; set; }
    public string HP { get; set; }
    public string? FrontText { get; set; }
    public string? EpicAction { get; set; }
    public bool DoubleSided { get; set; }
    public string? BackText { get; set; }
    public string Rarity { get; set; }
    public bool Unique { get; set; }
    public List<CardKeyword>? Keywords { get; set; }
    public string Artist { get; set; }
    public string FrontArt { get; set; }
    public string? BackArt { get; set; }
    public string VariantType { get; set; }
    public decimal? MarketPrice { get; set; } 
  }
}
