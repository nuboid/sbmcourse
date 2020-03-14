using MySoftwareCompany.DDD;
using System.Collections.Generic;

namespace MyApplication.DomainModel.DeliveryAggregate
{
    public class DeliveryPart : BaseEntity
    {
        public double Weight { get; set; }
        public double Volume { get; set; }
        public List<string> ProductIds{ get; set; }
    }
}
