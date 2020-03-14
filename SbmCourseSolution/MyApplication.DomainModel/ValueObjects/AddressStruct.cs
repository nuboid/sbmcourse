using MySoftwareCompany.DDD;

namespace MyApplication.DomainModel.ValueObjects
{
    public class AddressStruct : BaseValueObject
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
    }
}
