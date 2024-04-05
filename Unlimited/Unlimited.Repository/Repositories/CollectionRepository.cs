using Enums;
using Microsoft.EntityFrameworkCore;
using Models;
using Unlimited.Repository.Interfaces;

namespace Unlimited.Repository.Repositories
{
  public class CollectionRepository : BaseRepository<Collection>, ICollectionRepository
  {
    private readonly UnlimitedDbContext _dbContext;

    public CollectionRepository(UnlimitedDbContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<bool> AddCardToCollection(Guid collectionId, CollectionCard cardToAdd)
    {
      var result = false;
      _dbContext.CollectionCards.Add(cardToAdd);
      await _dbContext.SaveChangesAsync();
      result = true;

      return result;
    }

    public async Task<bool> DoesCardExistInCollection(Guid collectionId, Guid cardId)
    {
      var exists = await _dbContext.CollectionCards
        .AnyAsync(cc => cc.CollectionId == collectionId && cc.CardId == cardId);
      //var collection = await _dbContext.Collections.Where(x => x.Id == collectionId).FirstOrDefaultAsync();      
      //var card = collection.Cards.Where(x => x.Id == cardId).FirstOrDefault();
      return exists;
    }

    public async Task<Guid> GetCollectionIdByUserId(Guid userId)
    {
      var collection = await _dbContext.Collections.FirstOrDefaultAsync(x => x.UserId == userId);
      return collection != null ? collection.Id : Guid.Empty;
    }
  }
}
