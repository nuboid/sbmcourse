using MyApplication.DomainModel.CustomerAggregate;
using MySoftwareCompany.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication.DomainInterfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}