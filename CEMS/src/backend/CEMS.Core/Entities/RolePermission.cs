using CEMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.Entities
{
    public class RolePermission:IHasId
    {
        public Guid Id { get; set; }

        public Role Role { get; set; }

        public Permission Permission { get; set; }

    }
}
