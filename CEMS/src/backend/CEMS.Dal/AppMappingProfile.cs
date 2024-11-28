using AutoMapper;
using CEMS.Dal.Models;

namespace CEMS.Dal
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<User, CEMS.Core.Entities.User>().ReverseMap();
            CreateMap<Attendee, CEMS.Core.Entities.Attendee>().ReverseMap();
            CreateMap<Conference, CEMS.Core.Entities.Conference>().ReverseMap();
            CreateMap<Moderator, CEMS.Core.Entities.Moderator>().ReverseMap();
            CreateMap<Permission, CEMS.Core.Entities.Permission>().ReverseMap();
            CreateMap<Role, CEMS.Core.Entities.Role>().ReverseMap();
            CreateMap<RolePermission, CEMS.Core.Entities.RolePermission>().ReverseMap();
            CreateMap<Session, CEMS.Core.Entities.Session>().ReverseMap();
            CreateMap<Speaker, CEMS.Core.Entities.Speaker>().ReverseMap();
            CreateMap<Talk, CEMS.Core.Entities.Talk>().ReverseMap();
            CreateMap<UserRole, CEMS.Core.Entities.UserRole>().ReverseMap();
            
        }
    }
}
