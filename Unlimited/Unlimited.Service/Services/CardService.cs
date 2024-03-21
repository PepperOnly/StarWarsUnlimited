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

    public Task<bool> AddCardAsync(IEnumerable<Card> cards)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Card> GetCards()
    {
      return _cardRepository.GetAll();
    }
  }
}
