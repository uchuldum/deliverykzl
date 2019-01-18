﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dolce_Vita.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Dolce_Vita.Domain;
using System;

namespace Dolce_Vita.Controllers
{
    public class AccountController : Controller
    {
        private Shifr shifr = new Shifr();

        private DolceVitaContext _context;
        public AccountController(DolceVitaContext context)
        {
            _context = context;
            DatabaseInitialize();
        }
        private void DatabaseInitialize()
        {
            if (!_context.Roles.Any())
            {
                string adminRoleName = "admin";
                string userRoleName = "user";

                string adminLogin = "admin";
                string adminPassword = shifr.Code("123456");

                // добавляем роли
                Role adminRole = new Role { Name = adminRoleName };
                Role userRole = new Role { Name = userRoleName };

                _context.Roles.Add(userRole);
                _context.Roles.Add(adminRole);

                // добавляем администратора
                _context.Users.Add(new User { Login = adminLogin, Password = adminPassword, Role = adminRole });

                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == shifr.Code(model.Password));
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Cabinet", "Admin");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    
    }
}
