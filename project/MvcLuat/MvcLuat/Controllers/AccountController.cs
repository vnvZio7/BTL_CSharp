using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MvcLuat.Data;
using MvcLuat.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MvcLuat.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyDbContext _context;

        public AccountController(MyDbContext context)
        {
            _context = context;
        }

            
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return View("Login");
        }
        [HttpPost]
        public IActionResult Login(User _userFromPage)
        {
            var _user = _context.Users.Where(m => m.Email == _userFromPage.Email && m.PassWord == _userFromPage.PassWord).FirstOrDefault();
            if (_user == null )
            {
                ViewBag.LoginStatus = 0;   

            }
            else
            {
                    var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, _user.UserName),
            new Claim(ClaimTypes.Role, _user.Role)
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                };

                 HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Account");
            }
            return View();

        }
    }
}