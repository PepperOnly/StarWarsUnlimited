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

      var collection = await _dbContext.Collections.Where(x => x.Id == collectionId).FirstOrDefaultAsync();
      if (collection != null)
      {
        collection.Cards.Add(cardToAdd);
        await _dbContext.SaveChangesAsync();
        result = true;
      }
      return result;
    }

    public async Task<bool> DoesCardExistInCollection(Guid collectionId, string number, int cardSet)
    {
      var result = false;

      var collection = await _dbContext.Collections.Where(x => x.Id == collectionId).FirstOrDefaultAsync();
      var card = collection.Cards.Where(x => x.Card.Number == number && x.Card.Set == (CardSet)cardSet).FirstOrDefault();
      if (card != null)
      {
        result = true;
      }

      return result;
    }

    public async Task<Guid> GetCollectionIdByUserId(Guid userId)
    {
      var collection = await _dbContext.Collections.FirstOrDefaultAsync(x => x.Owner.Id == userId);
      return collection != null ? collection.Id : Guid.Empty;
    }
  }
}
