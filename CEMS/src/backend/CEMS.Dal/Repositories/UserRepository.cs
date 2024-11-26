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
    public class UserRepository : IUserRepository
    {
        public Task<User> AddAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRoleToUserAsync(Guid userId, Guid roleId)
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

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool includeTracking)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetConferenceAttendeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetConferenceModeratorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetConferenceSpeakersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
