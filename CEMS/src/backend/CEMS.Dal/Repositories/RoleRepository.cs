using CEMS.Core.Entities;
using CEMS.Core.RepositoryInterfaces.DalRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Dal.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public Task<Role> AddAsync(Role item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetByIdsAsync(IEnumerable<Guid> ids, bool includeTracking)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(Expression<Func<Role, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
