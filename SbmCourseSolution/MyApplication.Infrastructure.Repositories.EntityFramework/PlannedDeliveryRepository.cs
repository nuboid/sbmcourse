﻿using MyApplication.DomainInterfaces;
using MyApplication.DomainModel.PlannedDeliveryAggregate;
using MyApplication.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication.Infrastructure.Repositories.EntityFramework
{
    public class PlannedDeliveryRepository : BaseRepository<PlannedDelivery>, IPlannedDeliveryRepository
    {
        public PlannedDeliveryRepository(DomainDbContext domainDbContext) : base(domainDbContext)
        {

        }
    }
}
