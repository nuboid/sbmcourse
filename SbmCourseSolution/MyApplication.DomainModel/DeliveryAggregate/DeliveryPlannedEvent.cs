using MySoftwareCompany.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication.DomainModel.DeliveryAggregate
{
    public class DeliveryPlannedEvent : BaseDomainEvent
    {

        public string Id { get; }

        public DeliveryPlannedEvent(string forDeliveryId)
        {
            Id = forDeliveryId;
        }
    }
}
