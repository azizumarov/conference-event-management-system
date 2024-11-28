using CEMS.Core.Interfaces;

namespace CEMS.Core.RepositoryInterfaces.DalRepositories
{
    public interface IHasIdRepository<T> : IRepository<T> where T : class, IHasId
    {
        Task<T> GetItemByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<List<T>> GetByIdsAsync(IEnumerable<Guid> ids);
        Task<List<T>> GetByIdsAsync(IEnumerable<Guid> ids, bool includeTracking);
    }
}
