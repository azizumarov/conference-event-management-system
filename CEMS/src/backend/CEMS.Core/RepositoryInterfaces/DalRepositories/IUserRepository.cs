using CEMS.Core.Entities;

namespace CEMS.Core.RepositoryInterfaces.DalRepositories
{
    public interface IUserRepository : IHasIdRepository<User>
    {
        Task<bool> AddRoleToUserAsync(Guid userId, Guid roleId);
        Task<List<User>> GetConferenceModeratorsAsync(Guid conferenceId);
        Task<List<User>> GetConferenceSpeakersAsync(Guid conferenceId);
        Task<List<User>> GetConferenceAttendeesAsync(Guid conferenceId);
    }
}
