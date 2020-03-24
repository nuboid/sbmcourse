using System;
using Microsoft.AspNetCore.Mvc;


namespace MyApplication.ApplicationServices.DeliveryService.Controllers
{
    [ApiController]
    public class PingController : Controller
    {
        [HttpGet("api/ping")]
        public String GetPing()
        {
            Console.WriteLine("PING Called "+ DateTime.Now.Ticks + " on " + this.HttpContext.Request.Host );
            return "pong from " + this.HttpContext.Request.Host;
        }
    }
}
