using CEMS.Core.Entities;
using CEMS.Core.Interfaces;
using CEMS.Core.RepositoryInterfaces.DalRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CEMS.AuthService
{
    public class AuthService(IUserRepository userRepository, IRoleRepository roleRepository, IPasswordHasher passwordHasher) : IAuthService
    {     
        public Task<bool> AssignRoleToUserAsync(Guid userId, Guid roleId)
        {
            return userRepository.AddRoleToUserAsync(userId, roleId);
        }

        public async Task<string?> AuthenticateUserAsync([FromBody] string login, [FromBody] string password)
        {
            var users = await userRepository.GetAllAsync();
            var user = users.FirstOrDefault(user => user.Login == login);
            if (user == null) throw new Exception("User Not Found");
            if (!passwordHasher.VerifyPassword(password, user.PasswordHash)) return null;
            return "Authenticated";
        }

        public Task<List<Role>> GetUserRolesAsync(Guid userId)
        {
            return roleRepository.GetUserRolesAsync(userId);
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            try
            {
                user.PasswordHash = passwordHasher.HashPassword(user.PasswordHash);
                var result = await userRepository.AddAsync(user);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
