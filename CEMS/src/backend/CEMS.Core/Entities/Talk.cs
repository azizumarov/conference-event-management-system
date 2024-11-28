using CEMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.Entities
{
    public class Talk:IHasId
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Presentation { get; set; }

        public DateTime ScheduledTime { get; set; }

        public virtual Speaker Speaker { get; set; }

    }
}
