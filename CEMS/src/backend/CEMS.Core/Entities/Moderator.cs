using CEMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.Entities
{
    public class Moderator:IHasId
    {
        public Guid Id { get; set; }

        public User User { get; set; }
        public Conference Conference { get; set; }
    }
}
