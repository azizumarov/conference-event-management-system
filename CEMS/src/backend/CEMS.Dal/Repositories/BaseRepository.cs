using AutoMapper;
using CEMS.Core.Interfaces;
using CEMS.Core.RepositoryInterfaces.DalRepositories;
using CEMS.Dal.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace CEMS.Dal.Repositories
{
    public class BaseRepository<TDomain, TEntity> (ICemsContextFactory dbFactory, IMapper mapper) : IRepository<TDomain>
        where TDomain : class, IHasId
        where TEntity : class, new()
    {
        public Task<TDomain> AddAsync(TDomain item)
        {
            var entity = new TEntity();
            mapper.Map(item, entity);
            var dbContext = dbFactory.CreateContext();
            dbContext.Add(entity);
            dbContext.SaveChanges();
            return Task.FromResult(item);
        }

        public async Task<bool> AnyAsync()
        {
            var dbContext = dbFactory.CreateContext();
            return await dbContext.Set<TEntity>().AnyAsync();
        }

        public virtual Task<List<TDomain>> GetAllAsync()
        {
            return dbFactory.CreateContext()
                .Set<TEntity>()
                .Select(item => mapper.Map<TDomain>(item))
                .ToListAsync();
        }

        public async virtual Task<int> GetCountAsync()
        {
            return await dbFactory.CreateContext().Set<TEntity>()
                .CountAsync();
        }
    }
}
