using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyResearch.Auth.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;

namespace MyResearch.Auth.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IAuthorizationService authorizationService,
            IDataProtectionProvider dataProtectionProvider)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _authorizationService = authorizationService;
            _dataProtectionProvider = dataProtectionProvider;
        }

        //[Authorize]

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio
        [HttpPost]

        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {

            var passwordToTest = "secret";
            var user = new IdentityUser
            {
                UserName = "KUCL",
                Email = "x@y.com",
            };
            await _userManager.CreateAsync(user, passwordToTest);

            await _userManager.AddClaimsAsync(user, new List<Claim> { new Claim("MyType", "MyValue") });
            var r = await _signInManager.PasswordSignInAsync("KUCL", passwordToTest, false, false);


            //login functionality
            //var user = await _userManager.FindByNameAsync(username);

            //if (user != null)
            //{
            //    //sign in
            //    var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

            //    if (signInResult.Succeeded)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}

            return RedirectToAction("Secret");
        }

        //https://localhost:44380/Home/Secret
        [Authorize(Policy = "MustHaveTheClaim")]
        public async Task<IActionResult> Secret()
        {

            var authResult = await _authorizationService.AuthorizeAsync(User, "MustHaveTheClaimAndTheCorrectValue");
            PeekIntoCookie();

            var user = GetUser();
            return View();
        }

        [AllowAnonymous]
        public IActionResult Info()
        {
            return View();
        }

        private void PeekIntoCookie()
        {
            var cookieManager = new ChunkingCookieManager();
            var cookie = cookieManager.GetRequestCookie(HttpContext, ".AspNetCore.Identity.Application");

            var dataProtector = _dataProtectionProvider.CreateProtector("Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware", "Identity.Application", "v2");

            //Get the decrypted cookie as plain text
            UTF8Encoding specialUtf8Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
            byte[] protectedBytes = Base64UrlTextEncoder.Decode(cookie);
            byte[] plainBytes = dataProtector.Unprotect(protectedBytes);
            string plainText = specialUtf8Encoding.GetString(plainBytes);


            //Get teh decrypted cookies as a Authentication Ticket
            TicketDataFormat ticketDataFormat = new TicketDataFormat(dataProtector);
            AuthenticationTicket ticket = ticketDataFormat.Unprotect(cookie);
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

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
