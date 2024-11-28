using AutoMapper;
using CEMS.Core.Interfaces;
using CEMS.Core.RepositoryInterfaces.DalRepositories;
using CEMS.Dal.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace CEMS.Dal.Repositories
{
    public class HasIdRepository<TDomain, TEntity>(ICemsContextFactory dbFactory, IMapper mapper) : BaseRepository<TDomain, TEntity>(dbFactory, mapper), IHasIdRepository<TDomain>
        where TDomain : class, IHasId
        where TEntity : class, new ()
    {
        public async virtual Task<TDomain> GetItemByIdAsync(Guid id)
        {
            return await dbFactory.CreateContext()
                .Set<TEntity>()
                .Select(item => mapper.Map<TDomain>(item))
                .FirstAsync(item => item.Id == id);
        }

        public async virtual Task<bool> ExistsAsync(Guid id)
        {
            return await dbFactory.CreateContext()
                .Set<TEntity>()
                .Select(item => mapper.Map<TDomain>(item))
                .AnyAsync(item => item.Id == id);
        }

        public async virtual Task<List<TDomain>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            return await dbFactory.CreateContext()
                .Set<TEntity>()
                .Select(item => mapper.Map<TDomain>(item))
                .Where(item => ids.Contains(item.Id))                
                .ToListAsync();
        }

        public Task<List<TDomain>> GetByIdsAsync(IEnumerable<Guid> ids, bool includeTracking)
        {
            if (includeTracking)
            {
                return GetByIdsAsync(ids);
            }

            var dbContext = dbFactory.CreateContext();

            return dbContext
                .Set<TEntity>()                
                .Select(item => mapper.Map<TDomain>(item))
                .Where(item => ids.Contains(item.Id))
                .ToListAsync();
        }
    }
}
