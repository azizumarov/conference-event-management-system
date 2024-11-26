using CEMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.Entities
{
    public class Speaker:IHasId
    {
        public Guid Id { get; set; }

        public virtual User User { get; set; }

        public virtual Talk Talk { get; set; }
    }
}
