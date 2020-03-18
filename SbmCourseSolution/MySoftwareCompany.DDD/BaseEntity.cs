using System;
using System.Collections.Generic;

namespace MySoftwareCompany.DDD
{
    public class BaseEntity
    {
        public string Id { get; set; }

        protected static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }

        public void SendDomainEvent(BaseDomainEvent domainEvent)
        {

        }
    }
}
