
using CEMS.Core.Entities;

namespace CEMS.Core.RepositoryInterfaces.DalRepositories
{
    public interface IRoleRepository : IHasIdRepository<Role>
    {
        public Task<List<Role>> GetUserRolesAsync(Guid userId);
    }
}
