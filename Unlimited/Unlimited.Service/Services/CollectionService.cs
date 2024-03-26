using Microsoft.VisualBasic;
using Unlimited.Repository.Interfaces;
using Unlimited.Service.Interfaces;

namespace Unlimited.Service.Services
{
  public class CollectionService : BaseService<Collection>, ICollectionService
  {
    private readonly ICollectionRepository _collectionRepository;
    public CollectionService(ICollectionRepository collectionRepository) : base(collectionRepository)
    {
      _collectionRepository = collectionRepository;
    }

    public Task<bool> AddCardToCollection(Guid userId, Guid collectionId, string number, int cardSet, int cardType, int quantity)
    {
      throw new NotImplementedException();
    }

    public async Task<Guid> GetCollectionIdByUserId(Guid userId)
    {
      return await _collectionRepository.GetCollectionIdByUserId(userId);
    }
  }
}
