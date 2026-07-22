using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Context;
using Portfolio.Models;
using System.Security.Claims;

namespace Portfolio.Controllers
{
    public class SettingsController : BaseAdminController
    {
        private readonly AppDBContext _context;
        public SettingsController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var admin = _context.Admins.FirstOrDefault(a => a.UserName == User.Identity!.Name);
            if (admin == null)
            {
                return NotFound();
            }

            var viewModel = new SettingsViewModel
            {
                UserName = admin.UserName,
                FullName = admin.FullName,
                ImageUrl = admin.ImageUrl
            };

            return View(viewModel);
        }

        [HttpPost("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(SettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var admin = _context.Admins.FirstOrDefault(a => a.UserName == User.Identity!.Name);
            if (admin == null)
            {
                return NotFound();
            }

            admin.FullName = model.FullName;
            admin.ImageUrl = model.ImageUrl;
            _context.SaveChanges();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.UserName),
                new Claim("fullName", admin.FullName),
                new Claim("imageUrl", admin.ImageUrl ?? string.Empty)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Ok();
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var admin = _context.Admins.FirstOrDefault(a => a.UserName == User.Identity!.Name);
            if (admin == null)
            {
                return NotFound();
            }

            if (admin.Password != model.CurrentPassword)
            {
                return BadRequest(new { message = "Mevcut şifre hatalı." });
            }

            admin.Password = model.NewPassword;
            _context.SaveChanges();

            return Ok();
        }
    }
}