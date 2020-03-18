using MyApplication.DomainModel.CustomerAggregate;
using MyApplication.DomainModel.DeliveryAggregate;
using MyApplication.DomainModel.Specifications;
using MySoftwareCompany.DDD;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.DomainModel.Tests
{
    public class DeliveryAggregateTests
    {
        [Test]
        public void DeliveryIsPlannedSpecification_ShouldWork_Positive()
        {
            var deliveries = new List<Delivery>();
            var delivery1 = Delivery.Create("customerID_1", "id1", "date");
            var delivery2 = Delivery.Create("customerID_2", "id2", "date");

            delivery2.SetPlanned();

            deliveries.Add(delivery1);
            deliveries.Add(delivery2);

            
            var specification = new DeliveryIsPlannedSpecification();

            var results = deliveries.Where(specification.Criteria.Compile()).ToList();
            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count);
            var singleResult = results[0];
            Assert.AreEqual(singleResult.ForCustomerId, "customerID_2");

        }

        [Test]
        public void DeliveryIsPlannedSpecification_ShouldWork_Negative()
        {
            var deliveries = new List<Delivery>();
            var delivery1 = Delivery.Create("customerID_1", "id1", "date");
            var delivery2 = Delivery.Create("customerID_2", "id2", "date");


            deliveries.Add(delivery1);
            deliveries.Add(delivery2);


            var specification = new DeliveryIsPlannedSpecification();

            var results = deliveries.Where(specification.Criteria.Compile()).ToList();
            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count);

        }
    }
}
