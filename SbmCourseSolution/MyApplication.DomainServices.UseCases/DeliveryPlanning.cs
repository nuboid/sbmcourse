using MyApplication.DomainInterfaces;
using MyApplication.DomainServices;
using MyApplication.DomainModel.DeliveryAggregate;
using MyApplication.Infrastructure.EntityFramework;
using MyApplication.Infrastructure.Repositories.EntityFramework;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using MySoftwareCompany.DDD;

namespace MyApplication.DomainServices.UseCases
{
    public static class DeliveryPlanning
    {
        private static DomainDbContext _domainDbContext;
        private static IDeliveryRepository _deliveryRepository;
        private static IPlannedDeliveryRepository _plannedDeliveryRepository;
        public static void Init()
        {
            //Create the Entity Frameworkd DBContext
            _domainDbContext = new DomainDbContext();

            //Create the database
            _domainDbContext.Database.EnsureCreated();

            //Create repositories.
            _deliveryRepository = new DeliveryRepository(_domainDbContext);
            _plannedDeliveryRepository = new PlannedDeliveryRepository(_domainDbContext);
        }

        public static void PlanDelivery()
        {
            Console.WriteLine("PlanDelivery");

            Delivery deliveryToBePlanned = CreateDeliveryToTest();

            //Create Unit Of Work
            var unitOfWork = new EntityFrameworkUnitOfWork();

            //Start Transaction
            var transaction = _domainDbContext.Database.BeginTransaction();
            unitOfWork.SetTransaction(transaction);

            try
            {
                //Instantiate the Domain Service
                var planDeliveryService = new PlanDeliveryService(
                    unitOfWork,
                    _deliveryRepository, 
                    _plannedDeliveryRepository);

                //Execute method.
                var ok = planDeliveryService.PlanDelivery(deliveryToBePlanned.Id, "10:00", 1);

                Console.WriteLine("Added Planned delivery");
            }
            catch (EntityValidationException ex)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var validationError in ex.ValidationErrors)
                {
                    Console.WriteLine(validationError);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            


        }

        private static Delivery CreateDeliveryToTest()
        {
            var customerId = Guid.NewGuid().ToString();
            var deliverAddressId = Guid.NewGuid().ToString();
            var date = DateTime.Now.AddDays(-1).ToUniversalTime().ToString();

            var deliveryToBePlanned = Delivery.Create(customerId, deliverAddressId, date);
            _deliveryRepository.Add(deliveryToBePlanned);

            Console.WriteLine("Added Delivery to be planned");
            return deliveryToBePlanned;
        }
    }
}
