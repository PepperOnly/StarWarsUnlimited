using Models;

namespace Unlimited.Repository.Interfaces
{
  public interface ICardRepository : IBaseRepository<Card>
  { 
    Task<IEnumerable<Card>> GetCardsBySet(string set);
  }
}
