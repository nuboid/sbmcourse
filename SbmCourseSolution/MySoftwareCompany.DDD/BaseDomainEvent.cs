using System;
using System.Collections.Generic;
using System.Text;

namespace MySoftwareCompany.DDD
{
    public abstract class BaseDomainEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
