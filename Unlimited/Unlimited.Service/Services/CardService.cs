using Enums;
using HelperFunctions;
using Models;
using OfficialUnlimitedDBIntegration.Core;
using Unlimited.Repository.Interfaces;
using Unlimited.Service.Interfaces;

namespace Unlimited.Service.Services
{
  public class CardService : BaseService<Card>, ICardService
  {
    public readonly ICardRepository _cardRepository;
    public readonly IUnlimitedClient _unlimitedClient;

    public CardService(ICardRepository cardRepository, IUnlimitedClient unlimitedClient) : base(cardRepository)
    {
      _cardRepository = cardRepository;
      _unlimitedClient = unlimitedClient;
    }

    public async Task<Card> GetCardByNumberAndSet(string number, int set)
    {
      return await _cardRepository.GetCardByNumberAndSet(number, (CardSet)set);
    }

    public async Task<IEnumerable<Card>> GetCardsBySet(string set)
    {
      return await _cardRepository.GetCardsBySet(set);
    }

    public async Task<int> ImportCardsBySet(string set)
    {
      //Make magic
      //Get cards
      var cards = await _unlimitedClient.GetCardSet(set);

      //Determine which need to be imported
      var cardsToAdd = cards.ToList();
      var cardsToRemove = await GetCardsBySet(set);

      if (cardsToRemove != null)
      {
        //some cards already in the db
        var comparer = new GenericEqualityComparer<Card>(
        (x, y) => x.Set == y.Set && x.Number == y.Number,
        obj => obj.Set.GetHashCode() ^ obj.Number.GetHashCode());

        cardsToAdd = cardsToAdd.Except(cardsToRemove, comparer).ToList();
      }

      //add range
      await _cardRepository.AddRange(cardsToAdd);

      //return how many are added
      return cardsToAdd.Count;
    }

    public async Task<int> UpdateCardsBySet(string set)
    {
      var cardsToUpdate = new List<Card>();

      // Get cards from the external API
      var cardsFromApi = (await _unlimitedClient.GetCardSet(set)).ToList();

      // Get cards from the database
      var cardsInDb = (await GetCardsBySet(set)).ToList();

      // Iterate through cards from API and update matching cards in the database
      foreach (var cardFromApi in cardsFromApi)
      {
        var cardInDb = cardsInDb.FirstOrDefault(x => x.Number == cardFromApi.Number && x.Set == cardFromApi.Set);

        if (cardInDb != null)
        {
          // Update card properties
          cardInDb.Name = cardFromApi.Name;
          cardInDb.Subtitle = cardFromApi.Subtitle ?? "None";
          cardInDb.Type = cardFromApi.Type;
          cardInDb.Aspects = cardFromApi.Aspects;
          cardInDb.Traits = cardFromApi.Traits;
          cardInDb.Arenas = cardFromApi.Arenas;
          cardInDb.Cost = cardFromApi.Cost ?? "0";
          cardInDb.Power = cardFromApi.Power ?? "0";
          cardInDb.HP = cardFromApi.HP ?? "0";
          cardInDb.FrontText = cardFromApi.FrontText;
          cardInDb.EpicAction = cardFromApi.EpicAction;
          cardInDb.DoubleSided = cardFromApi.DoubleSided;
          cardInDb.BackText = cardFromApi.BackText;
          cardInDb.Rarity = cardFromApi.Rarity;
          cardInDb.Unique = cardFromApi.Unique;
          cardInDb.Keywords = cardFromApi.Keywords;
          cardInDb.Artist = cardFromApi.Artist;
          cardInDb.FrontArt = cardFromApi.FrontArt;
          cardInDb.BackArt = cardFromApi.BackArt;
          cardInDb.VariantType = cardFromApi.VariantType;
          cardInDb.MarketPrice = cardFromApi.MarketPrice;

          cardsToUpdate.Add(cardInDb);
        }
      }

      // Update cards in the database
      await _cardRepository.UpdateRange(cardsToUpdate);

      return cardsToUpdate.Count;
    }
  }
}
