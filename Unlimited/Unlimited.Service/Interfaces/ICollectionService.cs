using Models;

namespace Unlimited.Service.Interfaces
{
  public interface ICollectionService : IBaseService<Collection>
  {
    public Task<Guid> GetCollectionIdByUserId(Guid userId);
    public Task<bool> AddCardToCollection(Guid userId, Guid collectionId, string number, int cardSet, int cardMake, int quantity);
    public Task<bool> DoesCardExistInCollection(Guid collectionId, Guid cardId);
    public Task UpdateCollectionValue(Guid collectionId);
  }
}
