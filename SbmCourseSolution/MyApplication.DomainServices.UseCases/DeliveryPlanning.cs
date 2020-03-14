using MyApplication.DomainModel.DeliveryAggregate;
using MyApplication.Infrastructure.EntityFramework;
using MyApplication.Infrastructure.Repositories.EntityFramework;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication.DomainServices.UseCases
{
    public static class DeliveryPlanning
    {
        private static DomainDbContext _domainDbContext;
        private static DeliveryRepository _deliveryRepository;
        private static PlannedDeliveryRepository _plannedDeliveryRepository;
        public static void Init()
        {
            _domainDbContext = new DomainDbContext();
            _deliveryRepository = new DeliveryRepository(_domainDbContext);
            _plannedDeliveryRepository = new PlannedDeliveryRepository(_domainDbContext);
        }

        public static void PlanDelivery()
        {

            var customerId = Guid.NewGuid().ToString();
            var deliverAddressId = Guid.NewGuid().ToString();
            var date = DateTime.Now.AddDays(-1).ToUniversalTime().ToString();
            var deliveryToBePlanned = Delivery.Create(customerId, deliverAddressId, date);

            deliveryToBePlanned.AddDeliverPart(Guid.NewGuid().ToString(), 10, 10, new List<string> {
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString()}
            );

            deliveryToBePlanned.AddDeliverPart(Guid.NewGuid().ToString(), 10, 10, new List<string> {
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString()}
            );



        }

    }
}
