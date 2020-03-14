using MySoftwareCompany.DDD;
using System.Collections.Generic;

namespace MyApplication.DomainModel.DeliveryAggregate
{
    public class DeliveryPart : BaseEntity
    {
        public string DeliveryId { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        //public List<DeliveryPartProductId> ProductIds{ get; set; }
    }

    //public class DeliveryPartProductId : BaseValueObject
    //{
    //    public string Id { get; set; }
    //}
}
