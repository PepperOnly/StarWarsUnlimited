using Microsoft.VisualBasic;

namespace Unlimited.Service.Interfaces
{
  public interface ICollectionService : IBaseService<Collection>
  {
    public Task<Guid> GetCollectionIdByUserId(Guid userId);
    public Task<bool> AddCardToCollection(Guid userId, Guid collectionId, string number, int cardSet, int cardType, int quantity);
  }
}
