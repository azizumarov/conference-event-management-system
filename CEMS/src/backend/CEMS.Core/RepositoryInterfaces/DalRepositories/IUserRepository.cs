using CEMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.RepositoryInterfaces.DalRepositories
{
    public interface IUserRepository : IHasIdRepository<User>
    {
        Task<bool> AddRoleToUserAsync(Guid userId, Guid roleId);
        Task<List<User>> GetConferenceModeratorsAsync();
        Task<List<User>> GetConferenceSpeakersAsync();
        Task<List<User>> GetConferenceAttendeesAsync();
    }
}
