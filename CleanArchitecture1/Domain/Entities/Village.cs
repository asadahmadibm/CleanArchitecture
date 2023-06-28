using Domain.Common;

namespace Domain.Entities
{
    public class Village : BaseAuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

    }
}
