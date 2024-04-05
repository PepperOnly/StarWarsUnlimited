using Models;
using Unlimited.Repository.Interfaces;

namespace Unlimited.Repository.Repositories
{
  public class CurrencyRepository : BaseRepository<CurrencyData>, ICurrencyRepository
  {
    private readonly UnlimitedDbContext _dbContext;

    public CurrencyRepository(UnlimitedDbContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }
  }
}
