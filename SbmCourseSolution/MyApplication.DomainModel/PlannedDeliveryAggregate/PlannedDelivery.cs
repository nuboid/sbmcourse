using MySoftwareCompany.DDD;
using System;

namespace MyApplication.DomainModel.PlannedDeliveryAggregate
{
    public class PlannedDelivery : BaseEntity
    {
        public string ForDeliveryId { get; set; } //1:1 same Id as Delivery
        public int DeliveryOrder { get; set; }
        public string ArrivalTimeForeseen { get; set; }

        public static PlannedDelivery Create(string deliveryId, string arrivalTimeForeseen, int deliveryOrder)
        {
            return new PlannedDelivery
            {
                Id = Guid.NewGuid().ToString(),
                ForDeliveryId = deliveryId,
                ArrivalTimeForeseen = arrivalTimeForeseen,
                DeliveryOrder = deliveryOrder
            };
        }
    }
}
