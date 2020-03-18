using MySoftwareCompany.DDD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyApplication.DomainModel.CustomerAggregate
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }

        private readonly List<DeliveryAddress> _deliveryAddresses = new List<DeliveryAddress>();
        
        public IEnumerable<DeliveryAddress> DeliveryAddresses
        {
            get { return new ReadOnlyCollection<DeliveryAddress>(_deliveryAddresses); }
        }

        public bool IsExpressCustomer { get; set; }
        public string Info { get; set; }

        public void AddDeliveryAddress(DeliveryAddress deliveryAddress)
        {
            _deliveryAddresses.Add(deliveryAddress);
        }
        public void UpdateDeliveryAddress(DeliveryAddress deliveryAddress)
        {

        }

        public static Customer Create(string name, string city, string info)
        {
            var isValid = true;
            var validationErrors = new List<string>();
            if (string.IsNullOrEmpty(name.Trim()))
            {
                isValid = false;
                validationErrors.Add("Name of customer cannot be empty");
            }
            if (string.IsNullOrEmpty(city.Trim()))
            {
                isValid = false;
                validationErrors.Add("City of customer cannot be empty");
            }
            if (!isValid)
            {
                throw new EntityValidationException(validationErrors);
            }

            return new Customer
            {
                Id = GenerateId(),
                Name = name,
                City = city,
                Info = info.Trim(),
                IsExpressCustomer = false
            };
        }
    }
}
