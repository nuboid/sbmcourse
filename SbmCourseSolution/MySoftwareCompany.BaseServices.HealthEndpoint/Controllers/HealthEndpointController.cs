using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MySoftwareCompany.BaseServices.HealthEndpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthEndpointController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "This is my healthstatus";
        }
    }
}
