using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Dolce_Vita.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Dolce_Vita.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        DolceVitaContext db;
        public AdminController(DolceVitaContext context)
        {
            db = context;
        }


        public IActionResult Cabinet()
        {
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return View();
        }



        //Categories
        public IActionResult Categories()
        {
            return View(db.Categories.ToList());
        }


       /* [HttpGet]
        public IActionResult GetCategory()
        {
           return new ObjectResult(db.Categories);
        }
        */
        [HttpGet]
        public async Task<IList> GetCategory()
        {
            return await db.Categories.ToListAsync();
        }

        [HttpPost]
        [ActionName("AddCategory")]
        public async Task<IActionResult> AddCategory(string name)
        {
            if (name == null)
                return BadRequest();

            await  db.Categories.AddAsync(new Category { Name = name });
            await db.SaveChangesAsync(); 
            
            

            return RedirectToAction("Categories", "Admin");
        }



        //Dishes
        public IActionResult Dishes()
        {
            return View();
        }

    }
}
