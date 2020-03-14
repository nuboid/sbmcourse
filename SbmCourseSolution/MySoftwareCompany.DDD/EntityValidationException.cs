using System;
using System.Collections.Generic;
using System.Text;

namespace MySoftwareCompany.DDD
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException(List<string> validationErrors)
        {
            ValidationErrors = validationErrors;
        }
        public List<string> ValidationErrors { get; set; }
    }
}
