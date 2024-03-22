using Models;

namespace Unlimited.Repository.Interfaces
{
  public interface ICardRepository
  {
    IEnumerable<Card> GetAll();
    Card GetById(Guid id);
    void Add(Card card);
    Task AddCards(IEnumerable<Card> cards);
    void Update(Card card);
    void Delete(Guid id);
    Task<IEnumerable<Card>> GetCardsAsync();
    Task<IEnumerable<Card>> GetCardsBySet(string set);
  }
}
