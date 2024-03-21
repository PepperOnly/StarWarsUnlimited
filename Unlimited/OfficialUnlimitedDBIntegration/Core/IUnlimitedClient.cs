using Models;

namespace OfficialUnlimitedDBIntegration.Core
{
    public interface IUnlimitedClient
    {
        public Task<IEnumerable<Card>> ImportCardSet(string set);
    }
}
