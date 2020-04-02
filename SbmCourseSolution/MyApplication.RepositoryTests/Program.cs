using MyApplication.DomainModel.CustomerAggregate;
using MyApplication.Infrastructure.EntityFramework;
using MyApplication.Infrastructure.Repositories.EntityFramework;
using System;
using System.Linq;

namespace MyApplication.RepositoryTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateDatabase();
            //Test_InsertCustomer();
            //Test_UpdateCustomer();
            Test_DeleteCustomer();
            //Test_UpdateCustomer_UpdateOneAddress_DeleteTheOther();
        }

        private static void Test_UpdateCustomer_UpdateOneAddress_DeleteTheOther()
        {
            using (var domainDbContext = new DomainDbContext())
            {
                var query = from c in domainDbContext.Customers
                            select c;
                var customerForid = query.FirstOrDefault();

                var repository = new CustomerRepository(domainDbContext);

                var customer = repository.GetById(customerForid.Id);


                customer.DeliveryAddresses[0].Address.AddressLine1 = "Changed !!";
                customer.DeliveryAddresses.RemoveAt(1);

                repository.Update(customer);
            }
        }

        private static void CreateDatabase()
        {
            System.IO.File.Delete("TestDatabase.db");

            using (var domainDbContext = new DomainDbContext())
            {
                domainDbContext.Database.EnsureCreated();
            }
        }

        private static void Test_DeleteCustomer()
        {
            using (var domainDbContext = new DomainDbContext())
            {
                var query = from c in domainDbContext.Customers
                            select c;
                var customerForid = query.FirstOrDefault();

                var repository = new CustomerRepository(domainDbContext);

                var customer = repository.GetById(customerForid.Id);

                repository.Delete(customer);
            }
        }

        private static void Test_UpdateCustomer()
        {
            using (var domainDbContext = new DomainDbContext())
            {
                var query = from c in domainDbContext.Customers
                            select c;
                var customerForid = query.FirstOrDefault();

                var repository = new CustomerRepository(domainDbContext);

                var customer = repository.GetById(customerForid.Id);

                customer.Name = "Test Changed";

                repository.Update(customer);
            }
        }

        private static void Test_InsertCustomer()
        {
            using (var domainDbContext = new DomainDbContext())
            {
                var customerId = Guid.NewGuid().ToString();
                var customer = new Customer();
                customer.Id = customerId;
                customer.Name = "Test";
                customer.Info = "Test";
                customer.AddDeliveryAddress(new DeliveryAddress
                {
                    CustomerId = customerId,
                    Id = Guid.NewGuid().ToString(),
                    Info = "Test 1",
                    Address = new DomainModel.ValueObjects.AddressStruct
                    {
                        AddressLine1 = "a",
                        AddressLine2 = "b",
                        AddressLine3 = "c",
                        City = "X"
                    }
                });
                customer.AddDeliveryAddress(new DeliveryAddress
                {
                    CustomerId = customerId,
                    Id = Guid.NewGuid().ToString(),
                    Info = "Test 2",
                    Address = new DomainModel.ValueObjects.AddressStruct
                    {
                        AddressLine1 = "d",
                        AddressLine2 = "e",
                        AddressLine3 = "f",
                        City = "X"
                    }
                });

                var repository = new CustomerRepository(domainDbContext);
                repository.Add(customer);
            }
        }
    }
}
