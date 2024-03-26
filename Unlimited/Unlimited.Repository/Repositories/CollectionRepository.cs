using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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

    public async Task<Guid> GetCollectionIdByUserId(Guid userId)
    {
      var collection = await _dbContext.Collections.FirstOrDefaultAsync(x => x.Owner.Id == userId);
      return collection != null ? collection.Id : Guid.Empty;
    }
  }
}
