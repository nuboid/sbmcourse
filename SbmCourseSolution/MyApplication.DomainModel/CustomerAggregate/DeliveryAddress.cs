using MyApplication.DomainModel.ValueObjects;
using MySoftwareCompany.DDD;

namespace MyApplication.DomainModel.CustomerAggregate
{
    public class DeliveryAddress : BaseEntity
    {
        public string CustomerId { get; set; }
        public AddressStruct Address { get; set; }
        public string LockCode { get; set; }
        public string Info { get; set; }

    }
}
