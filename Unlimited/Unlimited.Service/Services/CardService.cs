using Models;
using Unlimited.Repository.Interfaces;
using Unlimited.Service.Interfaces;

namespace Unlimited.Service.Services
{
  public class CardService : ICardService
  {
    public readonly ICardRepository _cardRepository;

    public CardService(ICardRepository cardRepository)
    {
      _cardRepository = cardRepository;
    }

    public async Task AddCardAsync(IEnumerable<Card> cards)
    {
      await _cardRepository.AddCards(cards);
    }

    public async Task<IEnumerable<Card>> GetCardsAsync()
    {
      return await _cardRepository.GetCardsAsync();
    }
  }
}
