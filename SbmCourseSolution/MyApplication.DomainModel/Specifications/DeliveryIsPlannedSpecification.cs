using MyApplication.DomainModel.CustomerAggregate;
using MyApplication.DomainModel.DeliveryAggregate;
using MySoftwareCompany.DDD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyApplication.DomainModel.Specifications
{
    public class DeliveryIsPlannedSpecification : ISpecification<Delivery>
    {
        public DeliveryIsPlannedSpecification()
        {
            Criteria = e => (e.IsPlanned);
        }
        public Expression<Func<Delivery, bool>> Criteria { get; }
    }
}
