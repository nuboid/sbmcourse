using MyApplication.DomainInterfaces;
using MyApplication.DomainModel.DeliveryAggregate;
using MyApplication.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication.Infrastructure.Repositories.EntityFramework
{
    public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(DomainDbContext domainDbContext) : base(domainDbContext)
        {

        }
    }
}
