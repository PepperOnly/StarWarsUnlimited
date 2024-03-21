using Models;

namespace Unlimited.Service.Interfaces
{
  public interface ICardService
  {
    public Task<IEnumerable<Card>> GetCardsAsync();
    public Task AddCardAsync(IEnumerable<Card> cards);
  }
}
