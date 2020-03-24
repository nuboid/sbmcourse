﻿using System;
using Microsoft.AspNetCore.Mvc;


namespace MyApplication.ApplicationServices.DeliveryService.Controllers
{
    [ApiController]
    public class PingController : Controller
    {
        [HttpGet("api/ping")]
        public String GetPing()
        {
            Console.WriteLine("PING Called "+ DateTime.Now.Ticks );
            return "pong ";
        }
    }
}
