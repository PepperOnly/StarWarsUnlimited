using Enums;
using Microsoft.EntityFrameworkCore;
using Models;
using Unlimited.Repository.Interfaces;

namespace Unlimited.Repository.Repositories
{
  public class CardRepository : BaseRepository<Card>, ICardRepository
  {
    private readonly UnlimitedDbContext _dbContext;

    public CardRepository(UnlimitedDbContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<Card> GetCardByNumberAndSet(string num, CardSet set)
    {
      return await _dbContext.Cards.Where(x => x.Number == num && x.Set == set).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Card>> GetCardsBySet(string set)
    {
      if (Enum.TryParse(set, true, out CardSet wantedSet))
      {
        return await _dbContext.Cards.Where(x => x.Set == wantedSet).ToListAsync();
      }
      else
      {
        throw new Exception($"No Set found matching {set}.");
      }
    }
  }
}
