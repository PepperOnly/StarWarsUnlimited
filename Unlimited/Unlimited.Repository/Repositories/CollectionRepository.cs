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
  }
}
