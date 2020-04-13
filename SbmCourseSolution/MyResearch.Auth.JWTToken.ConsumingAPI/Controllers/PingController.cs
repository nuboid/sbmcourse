using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MyResearch.Auth.JWTToken.ConsumingAPI.Controllers
{
    [ApiController]
    public class PingSecureController : Controller
    {
        [Authorize()]
        [HttpGet("api/pingsecure")]
        public String GetPingSecure()
        {
            return "pong " + GetUser();
        }


        private string GetUser()
        {
            try
            {
                var identity = this.User;
                var name = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                                   .Select(c => c.Value).SingleOrDefault();
                if (name != null)
                {
                    return name;
                }
                return "dummy";
            }
            catch (Exception ex)
            {

                return "dummy";
            }

        }
    }
}
