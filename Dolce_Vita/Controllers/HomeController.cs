using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Dolce_Vita.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return View();
        }
      
        public IActionResult About()
        {
            ViewData["Message"] = "THIS IS ABOUT.";

            return View();
        }

    }
}
