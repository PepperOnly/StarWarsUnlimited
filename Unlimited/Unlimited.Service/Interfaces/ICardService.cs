using Models;

namespace Unlimited.Service.Interfaces
{
  public interface ICardService : IBaseService<Card>
  {    
    public Task<int> ImportCardsBySet(string set);
    public Task<int> UpdateCardsBySet(string set);
    public Task<IEnumerable<Card>> GetCardsBySet(string set);
    public Task<Card> GetCardByNumberAndSet(string number, int set);
  }
}
