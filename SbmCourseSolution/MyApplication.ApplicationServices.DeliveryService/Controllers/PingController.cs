using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace MyApplication.ApplicationServices.DeliveryService.Controllers
{
    [ApiController]
    public class PingController : Controller
    {
        [HttpGet("api/ping")]
        public String GetPing()
        {
            return "pong ";
        }
    }
}
