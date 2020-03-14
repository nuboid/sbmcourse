using MyApplication.DomainModel.CustomerAggregate;
using MySoftwareCompany.DDD;
using NUnit.Framework;

namespace MyApplication.DomainModel.Tests
{
    public class CustomerAggregateTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatingValidCustomer_ShouldHaveId()
        {
            var customer = Customer.Create("NAME", "CITY", "info");
            Assert.IsNotNull(customer);
            Assert.IsFalse(string.IsNullOrEmpty(customer.Id));

        }

        [Test]
        public void CreatingInValidCustomer_CityNotFilledIn_ShouldThrowValidationException()
        {
            Assert.Throws<EntityValidationException>(
                () => Customer.Create("NAME", "", "info")
                );
        }
    }
}