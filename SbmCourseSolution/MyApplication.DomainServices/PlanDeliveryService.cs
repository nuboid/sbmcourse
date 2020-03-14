using MyApplication.DomainModel.DeliveryAggregate;
using MyApplication.DomainModel.PlannedDeliveryAggregate;
using System;

namespace MyApplication.DomainServices
{
    public class PlanDeliveryService
    {
        public Delivery DeliveryToBePlanned { get; set; }
        public PlannedDelivery PlannedDelivery { get; set; }
        public void PlanDelivery(string arrivalTimeForeseen, int deliveryOrder)
        {
            PlannedDelivery = PlannedDelivery.Create(DeliveryToBePlanned.Id, arrivalTimeForeseen, deliveryOrder);
            DeliveryToBePlanned.IsPlanned = true;
        }
    }
}
