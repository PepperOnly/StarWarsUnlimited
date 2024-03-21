using Microsoft.EntityFrameworkCore;
using Models;
using Unlimited.Repository.Interfaces;

namespace Unlimited.Repository.Repositories
{
  public class CardRepository : ICardRepository
  {
    private readonly UnlimitedDbContext _dbContext;

    public CardRepository(UnlimitedDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<Card> GetAll()
    {
      return _dbContext.Cards.ToList();
    }

    public Card GetById(Guid id)
    {
      return _dbContext.Cards.FirstOrDefault(c => c.Id == id);
    }

    public void Add(Card card)
    {
      _dbContext.Cards.Add(card);
      _dbContext.SaveChanges();
    }

    public void Update(Card card)
    {
      _dbContext.Entry(card).State = EntityState.Modified;
      _dbContext.SaveChanges();
    }

    public void Delete(Guid id)
    {
      var customer = _dbContext.Cards.Find(id);
      if (customer != null)
      {
        _dbContext.Cards.Remove(customer);
        _dbContext.SaveChanges();
      }
    }

    public async Task AddCards(IEnumerable<Card> cards)
    {
      _dbContext.Cards.AddRange(cards);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Card>> GetCardsAsync()
    {
      return await _dbContext.Cards.ToListAsync();
    }
  }
}
