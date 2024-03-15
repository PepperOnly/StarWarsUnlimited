using Models;

namespace Unlimited.Repository.Interfaces
{
  public interface ICardRepository
  {
    IEnumerable<Card> GetAll();
    Card GetById(Guid id);
    void Add(Card card);
    void Update(Card card);
    void Delete(Guid id);
  }
}
