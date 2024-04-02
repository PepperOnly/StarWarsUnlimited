using Enums;
using Models;

namespace Unlimited.Repository.Interfaces
{
  public interface ICardRepository : IBaseRepository<Card>
  { 
    Task<IEnumerable<Card>> GetCardsBySet(string set);
    Task<Card> GetCardByNumberAndSet(string num, CardSet set);
  }
}
