using AutoMapper.Configuration;
using HelperFunctions;
using Models;
using OfficialUnlimitedDBIntegration.Core;
using Unlimited.Repository.Interfaces;
using Unlimited.Service.Interfaces;

namespace Unlimited.Service.Services
{
  public class CardService : ICardService
  {
    public readonly ICardRepository _cardRepository;
    public readonly IUnlimitedClient _unlimitedClient;

    public CardService(ICardRepository cardRepository, IUnlimitedClient unlimitedClient)
    {
      _cardRepository = cardRepository;
      _unlimitedClient = unlimitedClient;
    }

    public async Task<int> AddCardAsync(IEnumerable<Card> cards)
    {
      await _cardRepository.AddCards(cards);
      return cards.Count();
    }

    public async Task<IEnumerable<Card>> GetCardsAsync()
    {
      return await _cardRepository.GetCardsAsync();
    }

    public async Task<IEnumerable<Card>> GetCardsBySet(string set)
    {
      return await _cardRepository.GetCardsBySet(set);
    }

    public async Task<int> ImportCardsBySet(string set)
    {
      //Make magic
      //Get cards
      var cards = await _unlimitedClient.ImportCardSet(set);

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
      await _cardRepository.AddCards(cardsToAdd);

      //return how many are added
      return cardsToAdd.Count;
    }
  }
}
