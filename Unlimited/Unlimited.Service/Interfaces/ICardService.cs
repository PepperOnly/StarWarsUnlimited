using Models;

namespace Unlimited.Service.Interfaces
{
  public interface ICardService
  {
    public IEnumerable<Card> GetCards();
  }
}
