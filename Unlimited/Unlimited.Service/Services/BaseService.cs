using Unlimited.Repository.Interfaces;
using Unlimited.Service.Interfaces;

namespace Unlimited.Service.Services
{
  public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
  {
    private readonly IBaseRepository<TEntity> _baseRepository;

    public BaseService(IBaseRepository<TEntity> baseRepository)
    {
      _baseRepository = baseRepository;
    }

    public async Task Add(TEntity entity)
    {
      await _baseRepository.Add(entity);
    }

    public async Task AddRange(IEnumerable<TEntity> entities)
    {
      await _baseRepository.AddRange(entities);
    }

    public async Task Delete(Guid id)
    {
      await _baseRepository.Delete(id);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
      return await _baseRepository.GetAll();
    }

    public async Task<TEntity> GetById(Guid id)
    {
      return await _baseRepository.GetById(id);
    }

    public async Task Update(TEntity entity)
    {
      await _baseRepository.Update(entity);
    }
  }
}
