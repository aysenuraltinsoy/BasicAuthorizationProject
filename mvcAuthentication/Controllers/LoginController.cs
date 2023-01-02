using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcAuthentication.Models.Context;
using mvcAuthentication.Models.Entities;
using System.Security.Claims;
using System.Security.Principal;

namespace mvcAuthentication.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context db=new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Manager mg)
        {
            var information = db.Managers.FirstOrDefault(x=>x.UserName==mg.UserName && x.Password==mg.Password);
            if (information!=null) 
            {
                //usage of claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,mg.UserName)
                };

                var userIdentity=new ClaimsIdentity(claims,"Login");   //association with claim id

                ClaimsPrincipal claimsPrincipal=new ClaimsPrincipal(userIdentity); // Put useridentity in object derive ctor from Define multi-identity claim class

                HttpContext.SignInAsync(claimsPrincipal); //Creates an encrypted cookie and appends it to the valid response
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Message = "Wrong username or password:(";
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn");
        }
    }
}
