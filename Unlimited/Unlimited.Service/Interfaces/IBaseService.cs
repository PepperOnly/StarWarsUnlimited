namespace Unlimited.Service.Interfaces
{
  public interface IBaseService<TEntity>
  {
    public Task<TEntity> GetById(Guid id);
    public Task<IEnumerable<TEntity>> GetAll();
    public Task Add(TEntity entity);
    public Task AddRange(IEnumerable<TEntity> entities);
    public Task Update(TEntity entity);
    public Task Delete(Guid id);
  }
}
