using MyApplication.DomainModel;
using MyApplication.DomainModel.CustomerAggregate;
using MyApplication.DomainModel.Specifications;
using MyApplication.DomainModel.ValueObjects;
using MyApplication.Infrastructure.EntityFramework;
using MyApplication.Infrastructure.Repositories.EntityFramework;
using System;

namespace MyApplication.Infrastructure.CreateDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.File.Delete("TestDatabase.db");

            var newCustomerId = Guid.NewGuid().ToString();

            using (var domainDbContext = new DomainDbContext())
            {
                domainDbContext.Database.EnsureCreated();
            }

            using (var domainDbContext = new DomainDbContext())
            {
                var repository = new CustomerRepository(domainDbContext);

                var customer = new Customer
                {
                    Id = newCustomerId,
                    City = "Maldegem"
                };

                customer.AddDeliveryAddress(new DeliveryAddress
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = new AddressStruct
                    {
                        AddressLine1 = "Kleitkalseide"
                    }
                });

                repository.Add(customer);
            }

            using (var domainDbContext = new DomainDbContext())
            {
                var repository = new CustomerRepository(domainDbContext);
                var customer = repository.GetById(newCustomerId);

                Console.WriteLine(customer.City);
                foreach (var deliveryAddress in customer.DeliveryAddresses)
                {
                    Console.WriteLine(deliveryAddress.Address.AddressLine1);
                }

                //var deliveryRepository = new DeliveryRepository(domainDbContext);
                //var specification = new DeliveryIsPlannedSpecification();
                //var list = deliveryRepository.List(specification);

            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
