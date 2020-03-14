using Microsoft.EntityFrameworkCore;
using MyApplication.DomainModel;
using MyApplication.DomainModel.CustomerAggregate;
using MyApplication.Infrastructure.EntityFramework;
using System.Linq;

namespace MyApplication.Infrastructure.Repositories.EntityFramework
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(DomainDbContext domainDbContext) : base(domainDbContext)
        {
            
        }

        public new Customer GetById(string Id)
        {
            return _domainDbContext.Set<Customer>()
                .Include("DeliveryAddresses")
                .SingleOrDefault(e => e.Id == Id);
        }
    }
}
