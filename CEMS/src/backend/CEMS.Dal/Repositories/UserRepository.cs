using AutoMapper;
using CEMS.Core.Entities;
using CEMS.Core.RepositoryInterfaces.DalRepositories;
using CEMS.Dal.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace CEMS.Dal.Repositories
{
    public class UserRepository(ICemsContextFactory dbFactory, IMapper mapper) : HasIdRepository<User, Dal.Models.User>(dbFactory, mapper), IUserRepository
    {
        public async Task<bool> AddRoleToUserAsync(Guid userId, Guid roleId)
        {
            var dbContext = dbFactory.CreateContext();
            var userRole = new Models.UserRole() { Id = Guid.NewGuid(), UserId = userId, RoleId = roleId };
            _ = dbContext.Add(userRole);
            _ = await dbContext.SaveChangesAsync();
            return true;
        }

        public Task<List<User>> GetConferenceAttendeesAsync(Guid conferenceId)
        {
            return dbFactory.CreateContext()
                .Attendees
                .Include(item => item.Talk)
                .ThenInclude(item => item.Session)                
                .Where(item => item.Talk.Session.ConferenceId == conferenceId)
                .Select(item => mapper.Map<User>(item))
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<List<User>> GetConferenceModeratorsAsync(Guid conferenceId)
        {
            return dbFactory.CreateContext()
                .Moderators                
                .Where(item => item.ConferenceId == conferenceId)
                .Select(item => mapper.Map<User>(item))
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<List<User>> GetConferenceSpeakersAsync(Guid conferenceId)
        {
            return dbFactory.CreateContext()
                .Speakers
                .Include(item => item.Talk)
                .ThenInclude(item => item.Session)
                .Where(item => item.Talk.Session.ConferenceId == conferenceId)
                .Select(item => mapper.Map<User>(item))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
