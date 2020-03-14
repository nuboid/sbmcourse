using MyApplication.DomainModel;
using MyApplication.DomainModel.CustomerAggregate;
using MyApplication.DomainModel.ValueObjects;
using MyApplication.Infrastructure.Repositories.JsonFiles;
using System;

namespace MyApplication.Infrastructure.CreateJsonFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var newCustomerId = Guid.NewGuid().ToString();

            var repository = new CustomerRepository(Environment.CurrentDirectory);

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

            Console.ReadKey();
        }
    }
}
