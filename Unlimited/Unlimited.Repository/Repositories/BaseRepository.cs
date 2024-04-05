using Microsoft.EntityFrameworkCore;
using Models;
using Unlimited.Repository.Interfaces;

namespace Unlimited.Repository.Repositories
{
  public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
  {
    private readonly UnlimitedDbContext _dbContext;

    public BaseRepository(UnlimitedDbContext dbContext)
    {
      _dbContext = dbContext;
    }


    public async Task<TEntity> GetById(Guid id)
    {
      return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
      return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task Add(TEntity entity)
    {
      _dbContext.Add(entity);
      await _dbContext.SaveChangesAsync();
    }

    public async Task AddRange(IEnumerable<TEntity> entities)
    {
      _dbContext.AddRange(entities);
      await _dbContext.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
      _dbContext.Entry(entity).State = EntityState.Modified;
      await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
      var entity = await GetById(id);
      if (entity != null)
      {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
      }
    }

    public async Task UpdateRange(IEnumerable<TEntity> entities)
    {
      _dbContext.UpdateRange(entities);
      await _dbContext.SaveChangesAsync();
    }
  }
}
