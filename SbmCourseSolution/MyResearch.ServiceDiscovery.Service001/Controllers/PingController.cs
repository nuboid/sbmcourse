using Microsoft.AspNetCore.Mvc;
using System;

namespace MyResearch.ServiceDiscovery.Service001.Controllers
{
    [ApiController]
    public class PingController : Controller
    {
        [HttpGet("api/ping")]
        public String GetPing()
        {
            Console.WriteLine("PING Called " + DateTime.Now.Ticks);
            return "pong ";
        }
    }
}
