using CEMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(User user);
        Task<string?> AuthenticateUserAsync(string login, string password);
        Task<bool> AssignRoleToUserAsync(Guid userId, Guid roleId);
        Task<List<Role>> GetUserRolesAsync(Guid userId);
    }
}
