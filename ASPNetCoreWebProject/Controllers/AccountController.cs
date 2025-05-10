using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ASPNetCoreWebProject.Models; // thay bằng namespace thực tế
using ASPNetCoreWebProject.Entities;
using System.Runtime.CompilerServices;

namespace ASPNetCoreWebProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly TmdtContext _context;

        public AccountController(TmdtContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Kiểm tra trong bảng CUSTOMER
            var customer = _context.Customers.FirstOrDefault(c => c.Username == model.Username && c.PassWord == model.Password);

            //Kiểm tra trong bảng SHIPPER
            var shipper = _context.Shippers.FirstOrDefault(s => s.Username == model.Username && s.PassWord == model.Password);

            if (customer != null || shipper != null)
            {
                var accountId = customer?.AccountId ?? shipper?.AccountId;

                var role = _context.PersonalInformations
                                   .Where(p => p.AccountId == accountId)
                                   .Select(p => p.Type)
                                   .FirstOrDefault();

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, role)
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            // Đăng nhập thất bại
            ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
