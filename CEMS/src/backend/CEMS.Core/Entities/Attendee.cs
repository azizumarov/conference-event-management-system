using CEMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.Entities
{
    public class Attendee:IHasId
    {
        public Guid Id { get; set; }
        public Vote Vote { get; set; } = Vote.None;
        public string Feedback { get; set; }
        public virtual User User { get; set; }
        public virtual Talk Talk { get; set; }
    }
}
