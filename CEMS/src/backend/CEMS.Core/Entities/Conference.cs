using CEMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.Entities
{
    public class Conference:IHasId
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Background { get; set; }

        public virtual List<Moderator> Moderators { get; set; }
        public virtual List<Session> Sessions { get; set; }
        public virtual List<Attendee> Attendees { get; set; }

    }
}
