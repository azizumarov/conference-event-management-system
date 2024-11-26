using CEMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.Entities
{
    public class Session:IHasId
    {
        public Guid Id { get; set; }

        public string Location { get; set; } 

        public virtual List<Talk> Talks { get; set; }
    }
}
