namespace Unlimited.Repository.Interfaces
{
  public interface IBaseRepository<TEntity>
  {
    public Task<TEntity> GetById(Guid id);
    public Task<IEnumerable<TEntity>> GetAll();
    public Task Add(TEntity entity);
    public Task AddRange(IEnumerable<TEntity> entities);
    public Task Update(TEntity entity);
    public Task UpdateRange(IEnumerable<TEntity> entities);
    public Task Delete(Guid id);
  }
}
