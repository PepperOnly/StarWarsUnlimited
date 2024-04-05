using Models;

namespace Unlimited.Repository.Interfaces
{
  public interface ICollectionRepository : IBaseRepository<Collection>
  {
    public Task<Guid> GetCollectionIdByUserId(Guid userId);
    public Task<bool> AddCardToCollection(Guid collectionId, CollectionCard cardToAdd);
    Task<bool> DoesCardExistInCollection(Guid collectionId, Guid cardId);
  }
}
