using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PawsForApplause.Controllers
{
    public class AccountController : Controller
    {
        //GET : /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        //Post : /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(string username, string password)
        {
            //Validate username and password
            if(username == "admin" && password == "admin123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, username), // unique id
                    new Claim(ClaimTypes.Name, "Admin"), // human readable name
                };

                //
                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                //Re-direct to returnurl or homepage

                string? returnUrl = Request.Query["ReturnUrl"];

                if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Users");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Username or Password";
            }
                return View();
        }

        //GET : /Account/Logout
        public IActionResult Logout()
        {
            return View();
        }

        //Post : /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> LogoutConfirmed()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }
}
