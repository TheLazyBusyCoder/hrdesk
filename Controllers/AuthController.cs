using HRDesk.Data;
using HRDesk.Models;
using HRDesk.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HRDesk.Controllers
{
    public class AuthController : Controller
    {
        readonly AppDbContext _dbcontext;
        public AuthController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(!_dbcontext.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError(nameof(model.Email) , "Invalid Input");
                return View(model);
            }

            PasswordHasher<User> hasher = new();
            User user = _dbcontext.Users.First(u => u.Email == model.Email);

            PasswordVerificationResult result = hasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            model.Password);

            if(!result.Equals(PasswordVerificationResult.Success))
            {
                ModelState.AddModelError(nameof(model.Email), "Invalid Input");
                return View(model);
            }

            List<Claim> claims =
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            ];

            ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            return RedirectToAction("Index" , "Dashboard");
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            
            if(_dbcontext.Users.Any(u => u.Email == register.Email))
            {
                ModelState.AddModelError(nameof(register.Email) , "Email already registered");
                return View(register);
            }

            PasswordHasher<User> hasher = new PasswordHasher<User>();

            User user = new()
            {
                Name = register.FullName,
                Email = register.Email
            };

            user.PasswordHash = hasher.HashPassword(user, register.Password);

            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();

            return RedirectToAction("Login" , "Auth");
        }

        [ValidateAntiForgeryToken]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login" , "Auth");
        }
    }
}
