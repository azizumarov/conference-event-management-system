using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.Interfaces
{
    public interface IHasId
    {
        public Guid Id { get; }
    }
}
