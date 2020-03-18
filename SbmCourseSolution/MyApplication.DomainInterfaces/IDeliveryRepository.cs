using MyApplication.DomainModel.DeliveryAggregate;
using MySoftwareCompany.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication.DomainInterfaces
{
    public interface IDeliveryRepository : IRepository<Delivery>
    {
    }
}
