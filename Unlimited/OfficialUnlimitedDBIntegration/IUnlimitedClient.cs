using Models;

namespace OfficialUnlimitedDBIntegration
{
  public interface IUnlimitedClient
  {
    public IEnumerable<Card> ImportCardSet(string set);
  }
}
