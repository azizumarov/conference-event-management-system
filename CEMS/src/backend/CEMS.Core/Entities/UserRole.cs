using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.Entities
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        public Guid GrantedById { get; set; }
        public virtual User GrantedBy { get; set; }
        public DateTime GrantedOn { get; set; }
    }
}
