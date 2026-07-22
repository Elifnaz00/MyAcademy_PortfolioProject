using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Models.Login;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var admin= _context.Admins.FirstOrDefault(x => x.UserName == loginViewModel.UserName && x.Password == loginViewModel.Password);

            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                return View(loginViewModel);
            }

            if (admin == null) { 
               
                return View(loginViewModel);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.UserName),
                new Claim("FullName", admin.FullName),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);  
            var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            HttpContext.Session.SetString("FullName", admin.FullName);

            return RedirectToAction("Index", "About");
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("FullName");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Default");
        }


    }
}
