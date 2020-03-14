using System;

namespace MySoftwareCompany.DDD
{
    public class BaseEntity
    {
        public string Id { get; set; }

        protected static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
