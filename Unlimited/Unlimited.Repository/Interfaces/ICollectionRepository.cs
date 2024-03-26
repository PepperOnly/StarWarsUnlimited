using Microsoft.VisualBasic;

namespace Unlimited.Repository.Interfaces
{
  public interface ICollectionRepository : IBaseRepository<Collection>
  {
    public Task<Guid> GetCollectionIdByUserId(Guid userId);
  }
}
