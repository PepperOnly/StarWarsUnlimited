using Microsoft.VisualBasic;
using Unlimited.Repository.Interfaces;
using Unlimited.Service.Interfaces;

namespace Unlimited.Service.Services
{
  public class CollectionService : BaseService<Collection>, ICollectionService
  {
    public CollectionService(IBaseRepository<Collection> baseRepository) : base(baseRepository)
    {
    }
  }
}
