using Models;

namespace Unlimited.Service.Interfaces
{
  public interface ICardService
  {
    public Task<IEnumerable<Card>> GetCardsAsync();
    public Task<int> AddCardAsync(IEnumerable<Card> cards);
    public Task<int> ImportCardsBySet(string set);
  }
}
