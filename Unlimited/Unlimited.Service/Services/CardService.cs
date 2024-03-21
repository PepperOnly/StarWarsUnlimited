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

    public async Task<int> ImportCardsBySet(string set)
    {
      //Make magic
      //Get cards
      var cards = await _unlimitedClient.ImportCardSet(set);

      //Determine which need to be imported

      //Map objects

      //add range

      //return how many are added
      return 0;
    }
  }
}
