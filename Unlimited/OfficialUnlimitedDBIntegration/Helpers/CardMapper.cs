using Enums;
using Models;
using Newtonsoft.Json.Linq;
using OfficialUnlimitedDBIntegration.Models;

namespace OfficialUnlimitedDBIntegration.Helpers
{
  public class CardMapper
  {
    public static IEnumerable<Card> MapToCard(IEnumerable<ImportedCard> importedCards)
    {
      foreach (var importedCard in importedCards)
      {
        yield return new Card
        {
          Set = StringToEnum<CardSet>(importedCard.Set),
          Number = importedCard.Number,
          Name = importedCard.Name,
          Subtitle = importedCard.Subtitle,
          Type = StringToEnum<CardType>(importedCard.Type),
          Aspects = importedCard.Aspects.Select(aspect => new CardAspect()).ToList(),
          Traits = importedCard.Traits.Select(trait => new CardTrait()).ToList(),
          Arenas = importedCard.Arenas.Select(arena => new CardArena()).ToList(),
          Cost = importedCard.Cost,
          Power = importedCard.Power,
          HP = importedCard.HP,
          FrontText = importedCard.FrontText,
          EpicAction = importedCard.EpicAction,
          DoubleSided = importedCard.DoubleSided,
          BackText = importedCard.BackText,
          Rarity = importedCard.Rarity,
          Unique = importedCard.Unique,
          Keywords = importedCard.Keywords?.Select(keyword => new CardKeyword()).ToList(),
          Artist = importedCard.Artist,
          FrontArt = importedCard.FrontArt,
          BackArt = importedCard.BackArt
        };
      }
    }

    //public static ImportedCard MapToImportedCard(Card card)
    //{
    //  return new ImportedCard
    //  {
    //    Set = card.Set,
    //    Number = card.Number,
    //    Name = card.Name,
    //    Subtitle = card.Subtitle,
    //    Type = card.Type,
    //    Aspects = card.Aspects.Select(aspect => aspect.Name).ToList(),
    //    Traits = card.Traits.Select(trait => trait.Name).ToList(),
    //    Arenas = card.Arenas.Select(arena => arena.Name).ToList(),
    //    Cost = card.Cost,
    //    Power = card.Power,
    //    HP = card.HP,
    //    FrontText = card.FrontText,
    //    EpicAction = card.EpicAction,
    //    DoubleSided = card.DoubleSided,
    //    BackText = card.BackText,
    //    Rarity = card.Rarity,
    //    Unique = card.Unique,
    //    Keywords = card.Keywords?.Select(keyword => new Dictionary<string, string>(keyword)).ToList(),
    //    Artist = card.Artist,
    //    FrontArt = card.FrontArt,
    //    BackArt = card.BackArt
    //  };
    //}

    public static TEnum StringToEnum<TEnum>(string input, bool ignorecase = true) where TEnum : struct
    {
      if (Enum.TryParse(input, ignorecase, out TEnum result))
      {
        return result;
      }
      throw new ArgumentException($"Value '{input}' cannot be converted to enum {typeof(TEnum)}.");
    }
  }
}
