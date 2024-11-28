using AutoMapper;
using CEMS.Core.Entities;
using CEMS.Core.RepositoryInterfaces.DalRepositories;
using CEMS.Dal.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace CEMS.Dal.Repositories
{
    public class RoleRepository(ICemsContextFactory dbFactory, IMapper mapper) : HasIdRepository<Role, Dal.Models.Role>(dbFactory, mapper), IRoleRepository
    {
        public async Task<List<Role>> GetUserRolesAsync(Guid userId)
        {
            
            return await dbFactory.CreateContext().Set<Dal.Models.UserRole>()
                .Where(item => item.UserId == userId)
                .Select(item => mapper.Map<Role>(item))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
