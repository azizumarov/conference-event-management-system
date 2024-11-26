using CEMS.Core.Interfaces;

namespace CEMS.Core.Entities
{
    public class Permission:IHasId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
